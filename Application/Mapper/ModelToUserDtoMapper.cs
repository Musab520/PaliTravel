using Domain.Model;
using Riok.Mapperly.Abstractions;
using Application.DTOModels;
using Application.DTOModels.User;

namespace Application.Mapper;

[Mapper]
public partial class ModelToUserDtoMapper
{
    public partial UserDto MapToDto(UserModel userModel);

    public partial UserModel MapToModel(UserDto userUpsertDto);
}
