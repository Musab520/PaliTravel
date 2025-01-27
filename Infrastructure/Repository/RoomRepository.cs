using Domain.IRepository;
using Domain.SieveModel;
using Infrastructure.Mapper;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace Infrastructure.Repository;

public class RoomRepository : IRoomRepository
{
    private readonly Context _roomContext;
    private readonly ModelToRoomMapper _mapper;
    private readonly ModelToAvailableRoomMapper _mapperAvailableRoom;
    public RoomRepository(Context context, ModelToRoomMapper mapper, SieveProcessor sieveProcessor, ModelToAvailableRoomMapper mapperAvailableRoom)
    {
        _roomContext = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _mapperAvailableRoom = mapperAvailableRoom;
    }

    public async Task<RoomModel?> Insert(RoomModel room)
    {
        Room baseRoom = _mapper.MapToRoom(room);

        await _roomContext.AddAsync(baseRoom);

        await _roomContext.SaveChangesAsync();

        RoomModel roomModel = _mapper.MapToModel(baseRoom);

        return roomModel;
    }

    public void Update(RoomModel room)
    {
        Room baseRoom = _mapper.MapToRoom(room);
        _roomContext.Update(baseRoom);
        _roomContext.SaveChanges();
    }

    public void Delete(RoomModel room)
    {
        Room baseRoom = _mapper.MapToRoom(room);
        _roomContext.Remove(baseRoom);
        _roomContext.SaveChanges();
    }

    public async Task<RoomModel?> GetById(Guid id)
    {
        RoomModel? room = await _roomContext.FindAsync<RoomModel>(id);
        return room;
    }

    public async Task<List<AvailableRoomModel?>> GetAvailableRoomsAsync()
    {
        List<AvailableRoom> list = await _roomContext.AvailableRooms.ToListAsync();
        List<AvailableRoomModel?> modelList = _mapperAvailableRoom.MapToModelList(list);

        return modelList;
    }
}