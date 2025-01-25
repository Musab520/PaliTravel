namespace Application.DTOModels.Reservation;

public class ReservationDto
{
    public Guid Id { get; set; }
    
    public Guid RoomId { get; set; }
    
    public DateTime CheckIn { get; set; }
    
    public DateTime CheckOut { get; set; }

    public DateTime CreatedOn { get; set; }
    
    public DateTime UpdateOn { get; set; }
    
    public double PricePurchased { get; set; }
}