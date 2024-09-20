using Microsoft.EntityFrameworkCore;

using Configuration;
using Models;
using DbContext;
using Seido.Utilities.SeedGenerator;

namespace Services;


public class csAnimalServiceDb: IAnimalsService {
    private const string seedSource = "./friends-seeds1.json";

    public async Task<List<csAnimal>> AfricanAnimals(int _count)
    {
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            return await db.Animals.Include(a => a.Zoo).Take(_count).ToListAsync();
        }
    }
    public async Task Seed(int _count)
    {
        var fn = Path.GetFullPath(seedSource);
        var _seeder = new csSeedGenerator(fn);
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            var zoos = _seeder.ItemsToList<csZoo>(5);
            var animals = _seeder.ItemsToList<csAnimal>(_count);

            foreach (var a in animals)
            {
                a.Zoo = _seeder.FromList(zoos);
            }
            
            
            db.Animals.AddRange(animals);
            await db.SaveChangesAsync();
        }
    }    
}