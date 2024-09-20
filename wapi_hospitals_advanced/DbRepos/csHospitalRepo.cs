using Microsoft.EntityFrameworkCore;

using Configuration;
using DbModels;
using DbContext;
using Seido.Utilities.SeedGenerator;

namespace DbRepos;

public class csHospitalRepo : IHospitalRepo
{

    private const string seedSource = "./friends-seeds1.json";

    public async Task<List<csHospitalDbM>> Hospitals(int _count)
    {
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            var hospitals = await db.Hospitals.Include(h => h.DoctorsDbM).Take(_count).ToListAsync();

            //Remove recursion in many-to-many relationships
            //as each doctors below to several hospitals, which has several doctors
            //which belongs to several hospitals.....
            hospitals.ForEach(h =>h.DoctorsDbM?.ForEach(d => d.ExludeNavProps()));
            return hospitals;
        }
    }
    public async Task Seed(int _count)
    {
        var fn = Path.GetFullPath(seedSource);
        var _seeder = new csSeedGenerator(fn);
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            var hospitals = _seeder.ItemsToList<csHospitalDbM>(5);
            var doctors = _seeder.ItemsToList<csDoctorDbM>(20);

            foreach (var d in doctors)
            {
                d.HospitalsDbM = _seeder.UniqueIndexPickedFromList(_seeder.Next(1,4), hospitals);
            }
            
            
            db.Doctors.AddRange(doctors);
            await db.SaveChangesAsync();
        }
    }
}
