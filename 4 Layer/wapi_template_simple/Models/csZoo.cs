using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

using Seido.Utilities.SeedGenerator;

namespace Models;

public class csZoo: ISeed<csZoo>
{
    [Key]
    public virtual Guid ZooId { get; set;}
    public string Name { get; set; }

    public virtual List<csAnimal> Animals { get; set; }
    public bool Seeded { get; set; } = false;
    public virtual csZoo Seed (csSeedGenerator _seeder)
    {
        ZooId = Guid.NewGuid();
        Name = $"Zoo in the the city {_seeder.City()}";
        return this;
    }
}



