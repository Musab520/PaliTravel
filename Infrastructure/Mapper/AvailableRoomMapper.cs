using Domain.Model;
using Riok.Mapperly.Abstractions;
using Infrastructure.Model;

namespace Infrastructure.Mapper;

[Mapper]
public partial class ModelToAvailableRoomMapper
{
    public partial AvailableRoom MapToAvailableRoom(AvailableRoomModel roomModel);

    public partial AvailableRoomModel MapToModel(AvailableRoom room);
    
    public partial List<AvailableRoomModel?> MapToModelList(List<AvailableRoom?> room);

}