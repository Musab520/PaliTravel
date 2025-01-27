namespace Domain.SieveModel;

public class ConfirmationModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public Guid ReservationId { get; set; }
    
    public Guid DealId { get; set; }
    public Guid ConfirmationNumber { get; set; } = Guid.NewGuid();

    public DateTime CreatedOn { get; set; } = new DateTime();
    
    public DateTime UpdateOn { get; set; } = new DateTime();
}