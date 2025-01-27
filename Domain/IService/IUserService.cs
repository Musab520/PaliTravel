using Domain.SieveModel;

namespace Domain.IService;

public interface IUserService
{
    void Insert(UserModel userModel);
    void Update(UserModel userModel);
    void Delete(UserModel userModel);
    UserModel GetById(int id);
    Task<UserModel?> GetByEmail(string email);
}