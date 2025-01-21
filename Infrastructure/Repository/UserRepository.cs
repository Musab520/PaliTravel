using AutoMapper;
using Domain.IRepository;
using Domain.Model;
using Infrastructure.Mapper;
using Infrastructure.Model;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly Context _userContext;
    private readonly ModelToUserMapper _mapper;
    
    public UserRepository(Context context, ModelToUserMapper mapper)
    {
        _userContext = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    }

    public void Insert(UserModel user)
    {
        _userContext.Add(user);
        _userContext.SaveChanges();
    }

    public void Update(UserModel user)
    {
        _userContext.Update(user);
        _userContext.SaveChanges();
    }

    public void Delete(UserModel user)
    {
        _userContext.Remove(user);
        _userContext.SaveChanges();
    }

    public async Task<UserModel?> GetById(Guid id)
    {
        UserModel? user = await _userContext.FindAsync<UserModel>(id);

        return user;
    }

    public async Task<UserModel?> GetByEmail(string email)
    {
        User? user = await _userContext.Users.SingleOrDefaultAsync(u => u.Email == email);
        UserModel userModel = _mapper.MapToModel(user);
        return userModel;
    }
}