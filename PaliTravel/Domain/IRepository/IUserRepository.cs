using PaliTravel.Data.Model;

namespace PaliTravel.Domain.IRepository;

public interface IUserRepository
{
    void Insert(User user);
    void Update(User user);
    void Delete(User user);
    Task<User?> GetById(Guid id);
    Task<User?> GetByEmail(string email);
}