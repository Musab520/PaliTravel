namespace Application.DTOModels.Deal;

public class DealDto
{
    public Guid Id { get; set; } = new Guid();
    
    public Guid RoomId { get; set; }
    
    public Guid HotelId { get; set; }
    
    public DateTime FromDate { get; set; }
    
    public DateTime ToDate { get; set; }

    public DateTime CreatedOn { get; set; }
    
    public DateTime UpdateOn { get; set; }
    
    public double Discount { get; set; }
}