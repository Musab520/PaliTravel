
using Domain.IRepository;
using Domain.SieveModel;
using Domain.IService;
using Sieve.Services;

namespace Domain.Service;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;
    private readonly SieveProcessor _sieveProcessor;


    public RoomService(IRoomRepository roomRepository, SieveProcessor sieveProcessor)
    {
        _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
        _sieveProcessor = sieveProcessor ?? throw new ArgumentNullException(nameof(sieveProcessor));
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
        List<AvailableRoomModel?> availableRoomModels = await _roomRepository.GetAvailableRoomsAsync();
        IQueryable<AvailableRoomModel?> query = availableRoomModels.AsQueryable();
        query = _sieveProcessor.Apply(availableRoomSieveModel, query);
        
        return query.ToList();
    }
}