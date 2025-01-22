using Application.DTOModels.City;
using Domain.Model;
using Riok.Mapperly.Abstractions;
namespace Application.Mapper;

[Mapper]
public partial class ModelToCityDtoMapper
{
    public partial CityDto MapToDto(UserModel userModel);

    public partial CityModel MapToModel(CityDto cityDto);
    
    public partial CityModel MapUpsertToModel(CityUpsertDto cityUpsertDto);
}
