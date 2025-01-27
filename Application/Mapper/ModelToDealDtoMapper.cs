using Application.DTOModels.Hotel;
using Application.DTOModels.Deal;
using Application.DTOModels.Room;
using Application.Mapping;
using Domain.Enum;
using Domain.SieveModel;
using Riok.Mapperly.Abstractions;
namespace Application.Mapper;

[Mapper]
public partial class ModelToDealDtoMapper
{
    public partial DealDto MapToDto(UserModel userModel);

    public partial DealModel MapToModel(DealDto dealDto);
    
    public partial DealModel MapUpsertToModel(DealUpsertDto dealUpsertDto);
}
