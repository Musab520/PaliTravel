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
        User baseUser = _mapper.MapToUser(user);
        _userContext.Add(baseUser);
        _userContext.SaveChanges();
    }

    public void Update(UserModel user)
    {
        User baseUser = _mapper.MapToUser(user);
        _userContext.Update(baseUser);
        _userContext.SaveChanges();
    }

    public void Delete(UserModel user)
    {
        User baseUser = _mapper.MapToUser(user);
        _userContext.Remove(baseUser);
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
        if (user != null)
        {
            UserModel userModel = _mapper.MapToModel(user);
            return userModel;
        }

        return null;
    }
}