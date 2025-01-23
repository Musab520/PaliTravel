using Application.DTOModels.Hotel;
using Application.DTOModels.Room;
using Domain.Model;
using Riok.Mapperly.Abstractions;
namespace Application.Mapper;

[Mapper]
public partial class ModelToRoomDtoMapper
{
    public partial RoomDto MapToDto(UserModel userModel);

    public partial RoomModel MapToModel(RoomDto roomDto);
    
    public partial RoomModel MapUpsertToModel(RoomUpsertDto roomUpsertDto);
}
