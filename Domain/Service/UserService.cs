
using Domain.IRepository;
using Domain.Model;
using Domain.IService;

namespace Domain.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }
    
    public void Insert(UserModel userModel)
    {
        _userRepository.Insert(userModel);
    }

    public void Update(UserModel userModel)
    {
        throw new NotImplementedException();
    }

    public void Delete(UserModel userModel)
    {
        throw new NotImplementedException();
    }

    public UserModel GetById(int id)
    {
        throw new NotImplementedException();
    }
    
    public async Task<UserModel?> GetByEmail(string email)
    {
        UserModel? user = await _userRepository.GetByEmail(email);
        return user;
    }
}