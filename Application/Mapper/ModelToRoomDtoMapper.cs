using Application.DTOModels.Hotel;
using Application.DTOModels.Room;
using Application.Mapping;
using Domain.Enum;
using Domain.SieveModel;
using Riok.Mapperly.Abstractions;
namespace Application.Mapper;

[Mapper]
public partial class ModelToRoomDtoMapper
{
    public partial RoomDto MapToDto(UserModel userModel);

    public partial RoomModel MapToModel(RoomDto roomDto);
    
    [MapProperty(nameof(RoomUpsertDto.Availability), nameof(RoomModel.Availability))]
    public partial RoomModel MapUpsertToModel(RoomUpsertDto roomUpsertDto);
    
    private static Availability MapStringToAvailability(string availability)
        => EnumMappings.MapStringToAvailability(availability);
}
