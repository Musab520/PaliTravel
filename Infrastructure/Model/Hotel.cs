using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Infrastructure.Model;

[Table("Hotel")] 
public class Hotel
{
    [Key]
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } 

    [Required]
    public int StarRating { get; set; } = 1;

    public string Owner { get; set; } = string.Empty;
    
    public decimal Latitude { get; set; } = 0;
    
    public decimal Longitude { get; set; } = 0;
    
    [Required]
    [ForeignKey("City")]
    public Guid CityId { get; set; }
    
    public DateTime CreatedOn { get; set; } = new DateTime();

    public DateTime UpdateOn { get; set; } = new DateTime();
}