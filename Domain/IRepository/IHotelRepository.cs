using Domain.Model;

namespace Domain.IRepository;

public interface IHotelRepository
{
    Task<HotelModel?> Insert(HotelModel hotel);
    void Update(HotelModel hotel);
    void Delete(HotelModel hotel);
    Task<HotelModel?> GetById(Guid id);
}