using Application.DTOModels.Hotel;
using Application.DTOModels.Reservation;
using Application.DTOModels.Room;
using Application.Mapping;
using Domain.Enum;
using Domain.Model;
using Riok.Mapperly.Abstractions;
namespace Application.Mapper;

[Mapper]
public partial class ModelToReservationDtoMapper
{
    public partial ReservationDto MapToDto(UserModel userModel);

    public partial ReservationModel MapToModel(ReservationDto reservationDto);
    
    public partial ReservationModel MapUpsertToModel(ReservationUpsertDto reservationUpsertDto);
}
