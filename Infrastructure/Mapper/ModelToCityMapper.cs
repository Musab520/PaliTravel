using Domain.Model;
using Riok.Mapperly.Abstractions;
using Infrastructure.Model;

namespace Infrastructure.Mapper;

[Mapper]
public partial class ModelToCityMapper
{
    public partial City MapToCity(CityModel cityModel);

    public partial CityModel MapToModel(City city);
}