using System.ComponentModel.DataAnnotations;
using PaliTravel.Domain.Enum;

namespace PaliTravel.Domain.Model;

public class UserModel
{

    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Email { get; set; } 
    
    public string PasswordHash { get; set; } = string.Empty;
    
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
    public UserRole UserRole { get; set; } = UserRole.User;
}