using Domain.IRepository;
using Domain.Model;
using Infrastructure.Mapper;
using Infrastructure.Model;

namespace Infrastructure.Repository;

public class CityRepository : ICityRepository
{
    private readonly Context _cityContext;
    private readonly ModelToCityMapper _mapper;

    public CityRepository(Context context, ModelToCityMapper mapper)
    {
        _cityContext = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    }

    public void Insert(CityModel city)
    {
        City baseCity = _mapper.MapToCity(city);
        _cityContext.Add(baseCity);
        _cityContext.SaveChanges();
    }

    public void Update(CityModel city)
    {
        City baseCity = _mapper.MapToCity(city);
        _cityContext.Update(baseCity);
        _cityContext.SaveChanges();
    }

    public void Delete(CityModel city)
    {
        City baseCity = _mapper.MapToCity(city);
        _cityContext.Remove(baseCity);
        _cityContext.SaveChanges();
    }

    public async Task<CityModel?> GetById(Guid id)
    {
        CityModel? city = await _cityContext.FindAsync<CityModel>(id);
        return city;
    }
}