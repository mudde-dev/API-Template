namespace Models;
public enum enAnimalKind {Zebra, Elephant, Lion, Leopard, Gasell}
public enum enAnimalMood { Happy, Hungry, Lazy, Sulky, Buzy, Sleepy };

public interface IAnimal
{
    public Guid AnimalId { get; set; }
    public enAnimalKind Kind { get; set; }
    public enAnimalMood Mood { get; set; }
    
    public int Age { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IZoo Zoo { get; set; }
}

public interface IZoo
{
    public Guid ZooId { get; set;}
    public string Name { get; set; }
    public List<IAnimal> Animals { get; set; }
}