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

    public async Task<CityModel?> Insert(CityModel city)
    {
        City baseCity = _mapper.MapToCity(city);

        await _cityContext.AddAsync(baseCity);

        await _cityContext.SaveChangesAsync();

        CityModel cityModel = _mapper.MapToModel(baseCity);

        return cityModel;
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