using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Versioning;
using Sieve.Attributes;

namespace Infrastructure.Model;

public class AvailableRoom
{
    [Key]
    public Guid RoomId { get; set; }
    public Guid HotelId { get; set; }
    [Sieve(CanFilter = true, CanSort = true)]
    public string HotelName { get; set; } = string.Empty;
    [Sieve(CanFilter = true, CanSort = true)]
    public int RoomNumber { get; set; }
    [Sieve(CanFilter = true, CanSort = true)]
    public decimal Price { get; set; }
    [Sieve(CanFilter = true, CanSort = true)]
    public double Discount { get; set; }
    [Sieve(CanFilter = true, CanSort = true)]
    public bool IsDiscounted { get; set; }
    [Sieve(CanFilter = true, CanSort = true)]
    public DateTime? DiscountStartDate { get; set; }
    [Sieve(CanFilter = true, CanSort = true)]
    public DateTime? DiscountEndDate { get; set; }
    [Sieve(CanFilter = true, CanSort = true)]
    public string Availability { get; set; } = string.Empty;
    [Sieve(CanFilter = true, CanSort = true)]
    public int? AdultCapacity { get; set; }
    [Sieve(CanFilter = true, CanSort = true)]
    public int? ChildCapacity { get; set; }
    [Sieve(CanFilter = true, CanSort = true)]
    public DateTime CreatedOn { get; set; }
    [Sieve(CanFilter = true, CanSort = true)]
    public DateTime UpdateOn { get; set; }
}