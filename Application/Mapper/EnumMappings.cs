using System;
using Domain.Enum;

namespace Application.Mapping
{
    public static class EnumMappings
    {
        public static Availability MapStringToAvailability(string availability)
        {
            return Enum.TryParse<Availability>(availability, true, out var result)
                ? result
                : throw new ArgumentException($"Invalid availability value: {availability}");
        }
    }
}