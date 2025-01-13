using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using PaliTravel.Data.Model;
using PaliTravel.Domain.IRepository;

namespace PaliTravel.Data.Repository;

public class UserRepository : IUserRepository
{
    private readonly Context _userContext;
    
    public UserRepository(Context context)
    {
        _userContext = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Insert(User user)
    {
        
        _userContext.Add(user);
        _userContext.SaveChanges();
    }

    public void Update(User user)
    {
        _userContext.Update(user);
        _userContext.SaveChanges();
    }

    public void Delete(User user)
    {
        _userContext.Remove(user);
        _userContext.SaveChanges();
    }

    public async Task<User?> GetById(Guid id)
    {
        Optional<User?> userOptional = await _userContext.FindAsync<User>(id);

        if (userOptional.HasValue) {
            return userOptional.Value;
        } 
        return null;
    }

    public async Task<User?> GetByEmail(string email)
    {
        Optional<User?> userOptional = await _userContext.Users.SingleOrDefaultAsync(u => u.Email == email);

        if (userOptional.HasValue) {
            return userOptional.Value;
        } 
        return null;
    }
}