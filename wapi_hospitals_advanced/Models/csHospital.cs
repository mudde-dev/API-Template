
using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;

public class csHospital : ISeed<csHospital>, IHospital
{
    public virtual Guid HospitalId { get; set; }= Guid.NewGuid();
    public string Name { get; set; }

    public virtual List<IDoctor> Doctors { get; set; } = null;

    public bool Seeded { get; set; }

    public virtual csHospital Seed(csSeedGenerator seedGenerator)
    {
        Name = $"Hospital in {seedGenerator.City()}";
        return this;
    }
}

public class csDoctor : ISeed<csDoctor>, IDoctor
{
    public virtual Guid DoctorId { get; set; } = Guid.NewGuid();
    public string FirstName { get; set;}
    public string LastName { get; set;}

    public virtual List<IHospital> Hospitals { get; set;} = null;

    public bool Seeded { get; set; }

    public virtual csDoctor Seed(csSeedGenerator seedGenerator)
    {
        FirstName = seedGenerator.FirstName;
        LastName = seedGenerator.LastName;
        return this;
    }
} 