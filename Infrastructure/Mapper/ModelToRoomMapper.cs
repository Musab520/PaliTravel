using Domain.SieveModel;
using Riok.Mapperly.Abstractions;
using Infrastructure.Model;

namespace Infrastructure.Mapper;

[Mapper]
public partial class ModelToRoomMapper
{
    public partial Room MapToRoom(RoomModel roomModel);

    public partial RoomModel MapToModel(Room room);
}