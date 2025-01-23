using Domain.IRepository;
using Domain.Model;
using Infrastructure.Mapper;
using Infrastructure.Model;

namespace Infrastructure.Repository;

public class RoomRepository : IRoomRepository
{
    private readonly Context _roomContext;
    private readonly ModelToRoomMapper _mapper;

    public RoomRepository(Context context, ModelToRoomMapper mapper)
    {
        _roomContext = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

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
}