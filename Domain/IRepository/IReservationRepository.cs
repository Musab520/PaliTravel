using Domain.Model;

namespace Domain.IRepository;

public interface IReservationRepository
{
    Task<ReservationModel?> Insert(ReservationModel reservation);
    void Update(ReservationModel reservation);
    void Delete(ReservationModel reservation);
    Task<ReservationModel?> GetById(Guid id);
    Task<ReservationModel?> Reserve(ReservationModel reservation);

}