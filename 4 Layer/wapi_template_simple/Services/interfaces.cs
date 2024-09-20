using Models;
namespace Services;

public interface IAnimalsService {

    public Task<List<csAnimal>> AfricanAnimals(int _count);
    public Task Seed(int _count);
}
