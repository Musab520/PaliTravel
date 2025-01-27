
using Domain.IRepository;
using Domain.SieveModel;
using Domain.IService;

namespace Domain.Service;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
    }
    
    public async Task<CityModel?> Insert(CityModel cityModel)
    {
        return await _cityRepository.Insert(cityModel);
    }

    public void Update(CityModel cityModel)
    {
        throw new NotImplementedException();
    }

    public void Delete(CityModel cityModel)
    {
        throw new NotImplementedException();
    }

    public CityModel GetById(int id)
    {
        throw new NotImplementedException();
    }
}