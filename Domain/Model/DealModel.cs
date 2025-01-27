namespace Domain.SieveModel;

public class DealModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public Guid RoomId { get; set; }
    
    public Guid HotelId { get; set; }
    
    public DateTime FromDate { get; set; }
    
    public DateTime ToDate { get; set; }

    public DateTime CreatedOn { get; set; }
    
    public DateTime UpdateOn { get; set; }
    
    public double Discount { get; set; }
}