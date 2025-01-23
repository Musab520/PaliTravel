
using Domain.IRepository;
using Domain.Model;
using Domain.IService;

namespace Domain.Service;

public class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
    }
    
    public async Task<HotelModel?> Insert(HotelModel hotelModel)
    {
        return await _hotelRepository.Insert(hotelModel);
    }

    public void Update(HotelModel hotelModel)
    {
        throw new NotImplementedException();
    }

    public void Delete(HotelModel hotelModel)
    {
        throw new NotImplementedException();
    }

    public HotelModel GetById(int id)
    {
        throw new NotImplementedException();
    }
}