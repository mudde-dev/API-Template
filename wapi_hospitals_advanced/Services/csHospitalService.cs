using Configuration;
using Models;
using DbRepos;

using Seido.Utilities.SeedGenerator;

namespace Services;


public class csHospitalServiceDb: IHospitalService {

    private IHospitalRepo _repo = null;


    public async Task<List<IHospital>> Hospitals(int _count) => (await _repo.Hospitals(_count)).ToList<IHospital>();
    public async Task Seed(int _count) => await _repo.Seed(_count);
    
    
    public csHospitalServiceDb(IHospitalRepo repo)
    {
        _repo = repo;
    }
}