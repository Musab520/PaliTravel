using Domain.Model;

namespace Domain.IRepository;

public interface IUserRepository
{
    void Insert(UserModel user);
    void Update(UserModel user);
    void Delete(UserModel user);
    Task<UserModel?> GetById(Guid id);
    Task<UserModel?> GetByEmail(string email);
}