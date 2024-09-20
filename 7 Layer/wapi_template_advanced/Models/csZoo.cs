using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;

public class csZoo: IZoo, ISeed<csZoo>
{
    public virtual Guid ZooId { get; set;}
    public string Name { get; set; }

    public virtual List<IAnimal> Animals { get; set; }
    public bool Seeded { get; set; } = false;
    public virtual csZoo Seed (csSeedGenerator _seeder)
    {
        ZooId = Guid.NewGuid();
        Name = $"Zoo in the the city {_seeder.City()}";
        return this;
    }
}