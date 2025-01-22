using Microsoft.AspNetCore.Mvc;

namespace Application.DTOModels.City;

public class CityUpsertDto
{
    public string Name { get; set; } 

    public string Country { get; set; }
    
    public string PostOffice { get; set; } = string.Empty;
    
    public DateTime CreatedOn { get; set; } = new DateTime();

    public DateTime UpdateDate { get; set; } = new DateTime();
}