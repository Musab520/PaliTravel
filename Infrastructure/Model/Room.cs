using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Model;

public class Room
{
    [Key]
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    [ForeignKey("Hotel")]
    public Guid HotelId { get; set; }
    
    [Required]
    public int RoomNumber { get; set; }
    
    [Required]
    public string Availability { get; set; }

    public int AdultCapacity { get; set; } = 3;

    public int ChildCapacity { get; set; } = 0;

    [Required]
    public decimal Price { get; set; }
    
    public DateTime CreatedOn { get; set; } = new DateTime();

    public DateTime UpdateOn { get; set; } = new DateTime();
}