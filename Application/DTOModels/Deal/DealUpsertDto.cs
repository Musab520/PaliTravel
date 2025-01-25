using Microsoft.AspNetCore.Mvc;

namespace Application.DTOModels.Deal;

public class DealUpsertDto
{
    public Guid RoomId { get; set; }
    
    public DateTime FromDate { get; set; }
    
    public DateTime ToDate { get; set; }

    public DateTime CreatedOn { get; set; }
    
    public DateTime UpdateOn { get; set; }
    
    public double Discount { get; set; }
}