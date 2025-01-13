using PaliTravel.Data.Model;
using PaliTravel.Domain.Model;

namespace PaliTravel.Application.Mapper;

using AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserModel, User>();
        CreateMap<User, UserModel>();
    }
}