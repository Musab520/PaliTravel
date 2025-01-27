using Domain.Enum;

namespace Domain.SieveModel;

public class RoomModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public Guid HotelId { get; set; }
    
    public int RoomNumber { get; set; }
    
    public Availability Availability { get; set; }

    public int AdultCapacity { get; set; } = 3;

    public int ChildCapacity { get; set; } = 2;

    public double Price { get; set; }
    
    public DateTime CreatedOn { get; set; } = new DateTime();

    public DateTime UpdateDate { get; set; } = new DateTime();
}