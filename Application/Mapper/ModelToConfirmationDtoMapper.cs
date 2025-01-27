using Application.DTOModels.Hotel;
using Application.DTOModels.Confirmation;
using Application.DTOModels.Room;
using Application.Mapping;
using Domain.Enum;
using Domain.SieveModel;
using Riok.Mapperly.Abstractions;
namespace Application.Mapper;

[Mapper]
public partial class ModelToConfirmationDtoMapper
{
    public partial ConfirmationDto MapToDto(UserModel userModel);

    public partial ConfirmationModel MapToModel(ConfirmationDto dealDto);
    
    public partial ConfirmationModel MapUpsertToModel(ConfirmationUpsertDto dealUpsertDto);
}
