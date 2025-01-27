namespace Domain.SieveModel;

public class CityModel
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } 

    public string Country { get; set; } = string.Empty;

    public string PostOffice { get; set; } = string.Empty;

    public DateTime CreatedOn { get; set; } = new DateTime();

    public DateTime UpdateDate { get; set; } = new DateTime();
}