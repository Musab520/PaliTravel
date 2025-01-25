using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Model;

public class Deal
{
    [Key]
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public Guid RoomId { get; set; }
    
    [Required]
    public Guid HotelId { get; set; }
    
    [Required]
    public double Discount { get; set; }
    
    [Required]
    public DateTime FromDate { get; set; } = new DateTime();
    
    [Required]
    public DateTime ToDate { get; set; } = new DateTime();

    public DateTime CreatedOn { get; set; } = new DateTime();

    public DateTime UpdateOn { get; set; } = new DateTime();
}