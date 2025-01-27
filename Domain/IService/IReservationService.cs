using Domain.SieveModel;

namespace Domain.IService;

public interface IReservationService
{
    Task<ReservationModel?> Insert(ReservationModel reservationModel);
    void Update(ReservationModel reservationModel);
    void Delete(ReservationModel reservationModel);
    ReservationModel GetById(int id);
    Task<ReservationModel?> Reserve(ReservationModel reservation);

}