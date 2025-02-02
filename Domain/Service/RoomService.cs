
using Domain.IRepository;
using Domain.Model;
using Domain.IService;

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
}