using Domain.Model;
using Riok.Mapperly.Abstractions;
using Infrastructure.Model;

namespace Infrastructure.Mapper;

[Mapper]
public partial class ModelToHotelMapper
{
    public partial Hotel MapToHotel(HotelModel hotelModel);

    public partial HotelModel MapToModel(Hotel hotel);
}