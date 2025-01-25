using Domain.Model;

namespace Domain.IRepository;

public interface IRoomRepository
{
    Task<RoomModel?> Insert(RoomModel room);
    void Update(RoomModel room);
    void Delete(RoomModel room);
    Task<RoomModel?> GetById(Guid id);
    
    Task<List<AvailableRoomModel?>> GetAvailableRoomsAsync(AvailableRoomSieveModel sieveModel);
}