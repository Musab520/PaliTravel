using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Versioning;

namespace Infrastructure.Model;

public class AvailableRoom
{
    [Key]
    public Guid RoomId { get; set; }
    public Guid HotelId { get; set; }
    public string HotelName { get; set; } = string.Empty;
    public int RoomNumber { get; set; }
    public decimal Price { get; set; }
    public double Discount { get; set; }
    public bool IsDiscounted { get; set; }
    public DateTime? DiscountStartDate { get; set; }
    public DateTime? DiscountEndDate { get; set; }
    public string Availability { get; set; } = string.Empty;
    public int? AdultCapacity { get; set; }
    public int? ChildCapacity { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdateOn { get; set; }
}