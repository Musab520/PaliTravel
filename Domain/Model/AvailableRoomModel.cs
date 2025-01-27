using System;

namespace Domain.SieveModel;

public class AvailableRoomModel
{
    public Guid RoomId { get; set; }
    public Guid HotelId { get; set; }
    public string HotelName { get; set; } = string.Empty;
    public int RoomNumber { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public bool IsDiscounted { get; set; }
    public DateTime? DiscountStartDate { get; set; }
    public DateTime? DiscountEndDate { get; set; }
    public string Availability { get; set; } = string.Empty;
    public int? AdultCapacity { get; set; }
    public int? ChildCapacity { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdateOn { get; set; }
}