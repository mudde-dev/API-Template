using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

using Models;
using Seido.Utilities.SeedGenerator;

namespace DbModels;


public class csZooDbM : csZoo, ISeed<csZooDbM>
{
    [Key]
    public override Guid ZooId { get; set; }


    [NotMapped]
    public override List<IAnimal> Animals { get => AnimalsDbM?.ToList<IAnimal>(); set => throw new NotImplementedException(); }

    [JsonIgnore]
    public List<csAnimalDbM> AnimalsDbM { get; set; }

    //Used to stop recursion in DbRepos when using .Include in many-to-many relationships
    public csZooDbM ExludeNavProps() 
    {
        AnimalsDbM = null;
        return this;
    }

    public override csZooDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed (_seeder);
        return this;
    }
}