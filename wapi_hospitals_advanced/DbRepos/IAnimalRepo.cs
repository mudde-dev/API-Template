using DbModels;
namespace DbRepos;

public interface IAnimalRepo
{
    public Task<List<csAnimalDbM>> AfricanAnimals(int _count);
    public Task Seed(int _count);
}

public interface IHospitalRepo
{
    public Task<List<csHospitalDbM>> Hospitals(int _count);
    public Task Seed(int _count);
}