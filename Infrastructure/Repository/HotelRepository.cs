using Domain.IRepository;
using Domain.Model;
using Infrastructure.Mapper;
using Infrastructure.Model;

namespace Infrastructure.Repository;

public class HotelRepository : IHotelRepository
{
    private readonly Context _hotelContext;
    private readonly ModelToHotelMapper _mapper;

    public HotelRepository(Context context, ModelToHotelMapper mapper)
    {
        _hotelContext = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    }

    public async Task<HotelModel?> Insert(HotelModel hotel)
    {
        Hotel baseHotel = _mapper.MapToHotel(hotel);

        await _hotelContext.AddAsync(baseHotel);

        await _hotelContext.SaveChangesAsync();

        HotelModel hotelModel = _mapper.MapToModel(baseHotel);

        return hotelModel;
    }

    public void Update(HotelModel hotel)
    {
        Hotel baseHotel = _mapper.MapToHotel(hotel);
        _hotelContext.Update(baseHotel);
        _hotelContext.SaveChanges();
    }

    public void Delete(HotelModel hotel)
    {
        Hotel baseHotel = _mapper.MapToHotel(hotel);
        _hotelContext.Remove(baseHotel);
        _hotelContext.SaveChanges();
    }

    public async Task<HotelModel?> GetById(Guid id)
    {
        HotelModel? hotel = await _hotelContext.FindAsync<HotelModel>(id);
        return hotel;
    }
}