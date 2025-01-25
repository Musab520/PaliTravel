using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Model;

public class Reservation
{
    [Key]
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public Guid RoomId { get; set; }
    
    [Required]
    public DateTime CheckIn { get; set; }
    
    [Required]
    public DateTime CheckOut { get; set; }

    public DateTime CreatedOn { get; set; } = new DateTime();
    
    public DateTime UpdateOn { get; set; } = new DateTime();
    
    [Required]
    public decimal PricePurchased { get; set; }

}