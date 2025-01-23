using Application.DTOModels.Hotel;
using Domain.Model;
using Riok.Mapperly.Abstractions;
namespace Application.Mapper;

[Mapper]
public partial class ModelToHotelDtoMapper
{
    public partial HotelDto MapToDto(UserModel userModel);

    public partial HotelModel MapToModel(HotelDto hotelDto);
    
    public partial HotelModel MapUpsertToModel(HotelUpsertDto hotelUpsertDto);
}
