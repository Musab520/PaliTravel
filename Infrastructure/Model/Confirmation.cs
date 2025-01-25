using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Model;

public class Confirmation
{
    [Key]
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public Guid ReservationId { get; set; }
    
    [Required]
    public Guid DealId { get; set; }
    
    [Required]
    public Guid ConfirmationNumber{ get; set; } = Guid.NewGuid();

    public DateTime CreatedOn { get; set; } = new DateTime();
    
    public DateTime UpdateOn { get; set; } = new DateTime();
}