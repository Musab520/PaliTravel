using Microsoft.AspNetCore.Mvc;

namespace Application.DTOModels.Hotel;

public class RoomUpsertDto
{
    public Guid HotelId { get; set; }
    
    public int RoomNumber { get; set; }
    
    public string Availability { get; set; }

    public int AdultCapacity { get; set; } = 3;

    public int ChildCapacity { get; set; } = 2;

    public double Price { get; set; }
    
    public DateTime CreatedOn { get; set; } = new DateTime();

    public DateTime UpdateDate { get; set; } = new DateTime();
}