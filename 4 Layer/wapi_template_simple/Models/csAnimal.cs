using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

using Seido.Utilities.SeedGenerator;

namespace Models;

public enum enAnimalKind {Zebra, Elephant, Lion, Leopard, Gasell}
public enum enAnimalMood { Happy, Hungry, Lazy, Sulky, Buzy, Sleepy };

public class csAnimal: ISeed<csAnimal>
{
    [Key]
    public virtual Guid AnimalId { get; set; } = Guid.NewGuid();
    public enAnimalKind Kind { get; set; }
    public enAnimalMood Mood { get; set; }

    #region adding more readability to an enum type in the database
    public virtual string strKind
    {
        get => Kind.ToString();
        set { }  //set is needed by EFC to include in the database, so I make it to do nothing
    }
    public virtual string strMood
    {
        get => Mood.ToString();
        set { } //set is needed by EFC to include in the database, so I make it to do nothing
    }
    #endregion

    public int Age { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual csZoo Zoo { get; set; }

    #region seeder
    public bool Seeded { get; set; } = false;

    public virtual csAnimal Seed (csSeedGenerator _seeder)
    {
        AnimalId = Guid.NewGuid();
        Seeded = true;
        Kind = _seeder.FromEnum<enAnimalKind>();
        Mood = _seeder.FromEnum<enAnimalMood>();
        Age = _seeder.Next(0, 11);
        Name = _seeder.PetName;
        Description = _seeder.LatinSentence;

        return this;
    }
    #endregion
    
}