namespace Domain.Model;

public class ReservationModel
{
    public Guid Id { get; set; } = new Guid();
    
    public Guid RoomId { get; set; }
    
    public Guid HotelId { get; set; }
    
    public DateTime CheckIn { get; set; }
    
    public DateTime CheckOut { get; set; }

    public DateTime CreatedOn { get; set; }
    
    public DateTime UpdateOn { get; set; }
    
    public double PricePurchased { get; set; }
}