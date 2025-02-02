using Microsoft.AspNetCore.Mvc;

namespace Application.DTOModels.Reservation;

public class ReservationUpsertDto
{
    public Guid RoomId { get; set; }
    
    public DateTime CheckIn { get; set; }
    
    public DateTime CheckOut { get; set; }

    public DateTime CreatedOn { get; set; }
    
    public DateTime UpdateOn { get; set; }
    
    public double PricePurchased { get; set; }
}