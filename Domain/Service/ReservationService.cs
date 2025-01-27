
using Domain.IRepository;
using Domain.SieveModel;
using Domain.IService;

namespace Domain.Service;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;

    public ReservationService(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
    }
    
    public async Task<ReservationModel?> Insert(ReservationModel reservationModel)
    {
        return await _reservationRepository.Insert(reservationModel);
    }
    
    public async Task<ReservationModel?> Reserve(ReservationModel reservationModel)
    {
        return await _reservationRepository.Reserve(reservationModel);
    }

    public void Update(ReservationModel reservationModel)
    {
        throw new NotImplementedException();
    }

    public void Delete(ReservationModel reservationModel)
    {
        throw new NotImplementedException();
    }

    public ReservationModel GetById(int id)
    {
        throw new NotImplementedException();
    }
}