using Domain.Model;
using Riok.Mapperly.Abstractions;
using Infrastructure.Model;

namespace Infrastructure.Mapper;

[Mapper]
public partial class ModelToUserMapper
{
    public partial User MapToUser(UserModel userModel);

    public partial UserModel MapToModel(User user);
}