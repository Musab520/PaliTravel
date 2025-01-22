using Domain.Model;

namespace Domain.IService;

public interface ICityService
{
    void Insert(CityModel cityModel);
    void Update(CityModel cityModel);
    void Delete(CityModel cityModel);
    CityModel GetById(int id);
}