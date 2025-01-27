
using Domain.IRepository;
using Domain.SieveModel;
using Domain.IService;
using Sieve.Services;

namespace Domain.Service;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;


    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
    }
    
    public async Task<RoomModel?> Insert(RoomModel roomModel)
    {
        return await _roomRepository.Insert(roomModel);
    }

    public void Update(RoomModel roomModel)
    {
        throw new NotImplementedException();
    }

    public void Delete(RoomModel roomModel)
    {
        throw new NotImplementedException();
    }

    public RoomModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<AvailableRoomModel?>> GetAvailableRoomsAsync(AvailableRoomSieveModel availableRoomSieveModel)
    {
        return await _roomRepository.GetAvailableRoomsAsync(availableRoomSieveModel);
    }
}