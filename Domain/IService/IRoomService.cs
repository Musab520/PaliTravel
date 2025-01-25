using Domain.Model;

namespace Domain.IService;

public interface IRoomService
{
    Task<RoomModel?> Insert(RoomModel roomModel);
    void Update(RoomModel roomModel);
    void Delete(RoomModel roomModel);
    RoomModel GetById(int id);
    
    Task<List<AvailableRoomModel?>> GetAvailableRoomsAsync(AvailableRoomSieveModel sieveModel);

}