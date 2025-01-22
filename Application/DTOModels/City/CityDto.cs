namespace Application.DTOModels.City;

public class CityDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public string PostOffice { get; set; } = string.Empty;

    public DateTime CreatedOn { get; set; }

    public DateTime UpdateDate { get; set; }
}