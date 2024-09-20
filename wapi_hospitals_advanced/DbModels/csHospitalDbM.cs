using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

using Models;
using Seido.Utilities.SeedGenerator;

namespace DbModels;

public class csHospitalDbM : csHospital, ISeed<csHospitalDbM>
{
    [Key]
    public override Guid HospitalId { get; set; }= Guid.NewGuid();

    [NotMapped]
    public override List<IDoctor> Doctors { get => DoctorsDbM?.ToList<IDoctor>(); set=>throw new NotImplementedException(); }

    [JsonIgnore]
    public List<csDoctorDbM> DoctorsDbM { get; set; } = null;

    //Used to stop recursion in DbRepos when using .Include
    public csHospitalDbM ExludeNavProps() 
    {
        DoctorsDbM = null;
        return this;
    }

    public override csHospitalDbM Seed(csSeedGenerator seedGenerator)
    {
        base.Seed(seedGenerator);
        return this;
    }
}

public class csDoctorDbM : csDoctor, ISeed<csDoctorDbM>
{
    [Key]
    public override Guid DoctorId { get; set; } = Guid.NewGuid();

    [NotMapped]
    public override List<IHospital> Hospitals { get => HospitalsDbM?.ToList<IHospital>(); set=>throw new NotImplementedException();}

    [JsonIgnore]
    public virtual List<csHospitalDbM> HospitalsDbM { get; set;} = null;
    
    public csDoctorDbM ExludeNavProps() 
    {
        HospitalsDbM = null;
        return this;
    }
    public override csDoctorDbM Seed(csSeedGenerator seedGenerator)
    {
        base.Seed(seedGenerator);
        return this;
    }
}