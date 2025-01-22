using Domain.Model;

namespace Domain.IRepository;

public interface ICityRepository
{
    void Insert(CityModel city);
    void Update(CityModel city);
    void Delete(CityModel city);
    Task<CityModel?> GetById(Guid id);
}