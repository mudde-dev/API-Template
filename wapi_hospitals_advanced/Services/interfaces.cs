using Models;

namespace Services;


public interface IAnimalsService {

    public Task<List<IAnimal>> AfricanAnimals(int _count);
    public Task Seed(int _count);
}


public interface IHospitalService {

    public Task<List<IHospital>> Hospitals(int _count);
    public Task Seed(int _count);
}
