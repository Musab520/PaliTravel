namespace Application.DTOModels.Hotel;

public class HotelDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } 
    
    public int StarRating { get; set; } = 1;

    public string Owner { get; set; } = string.Empty;
    
    public decimal Latitude { get; set; } = 0;
    
    public decimal Longitude { get; set; } = 0;
    
    public Guid CityId { get; set; }
    
    public DateTime CreatedOn { get; set; } = new DateTime();

    public DateTime UpdateDate { get; set; } = new DateTime();
}