using Domain.SieveModel;

namespace Domain.IService;

public interface IRoomService
{
    Task<RoomModel?> Insert(RoomModel roomModel);
    void Update(RoomModel roomModel);
    void Delete(RoomModel roomModel);
    RoomModel GetById(int id);
    
    Task<List<AvailableRoomModel?>> GetAvailableRoomsAsync(Sieve.Models.SieveModel sieveModel);

}