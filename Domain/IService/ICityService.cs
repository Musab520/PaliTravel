using Domain.Model;

namespace Domain.IService;

public interface ICityService
{
    Task<CityModel?> Insert(CityModel cityModel);
    void Update(CityModel cityModel);
    void Delete(CityModel cityModel);
    CityModel GetById(int id);
}