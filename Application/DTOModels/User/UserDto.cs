using Domain.Enum;

namespace Application.DTOModels.User;

public class UserDto
{
    public Guid Id { get; set; }
    
    public string Email { get; set; } 
    
    public string PasswordHash { get; set; } = string.Empty;
    
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
    public UserRole UserRole { get; set; } = UserRole.User;
}