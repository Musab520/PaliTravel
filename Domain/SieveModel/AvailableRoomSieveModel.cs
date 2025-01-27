using Sieve.Attributes;
using System;
using Sieve.Models;

namespace Domain.SieveModel
{
    public class AvailableRoomSieveModel : Sieve.Models.SieveModel
    {
        [Sieve(CanFilter = true, CanSort = true)]
        public string HotelName { get; set; } = string.Empty;

        [Sieve(CanFilter = true, CanSort = true)]
        public int RoomNumber { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public decimal Price { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public decimal Discount { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public bool IsDiscounted { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Availability { get; set; } = string.Empty;

        public DateTime? DiscountStartDate { get; set; }
        public DateTime? DiscountEndDate { get; set; }

        public int? AdultCapacity { get; set; }
        public int? ChildCapacity { get; set; }
    }
}