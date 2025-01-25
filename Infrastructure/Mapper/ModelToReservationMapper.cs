using Domain.Model;
using Riok.Mapperly.Abstractions;
using Infrastructure.Model;

namespace Infrastructure.Mapper;

[Mapper]
public partial class ModelToReservationMapper
{
    public partial Reservation MapToReservation(ReservationModel reservationModel);

    public partial ReservationModel MapToModel(Reservation reservation);
}