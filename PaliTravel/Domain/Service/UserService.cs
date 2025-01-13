using AutoMapper;
using Microsoft.CodeAnalysis;
using PaliTravel.Data.Model;
using PaliTravel.Domain.IRepository;
using PaliTravel.Domain.Model;

namespace PaliTravel.Domain.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public void Insert(UserModel userModel)
    {
        User user = _mapper.Map<User>(userModel);
        _userRepository.Insert(user);
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
        Optional<User?> userOptional = await _userRepository.GetByEmail(email);
        if (userOptional.HasValue)
        {
            return _mapper.Map<UserModel>(userOptional.Value);
        }
        else
        {
            return null;
        }
    }
}