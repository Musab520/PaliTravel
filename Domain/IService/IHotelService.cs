using Domain.Model;

namespace Domain.IService;

public interface IHotelService
{
    Task<HotelModel?> Insert(HotelModel hotelModel);
    void Update(HotelModel hotelModel);
    void Delete(HotelModel hotelModel);
    HotelModel GetById(int id);
}