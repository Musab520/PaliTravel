using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaliTravel.Data.Model;

[Table("Users")] 
public class User
{
    [Key]
    [Required]
    public Guid Id { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; } 

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    [Required]
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    [Required]
    public string UserRole { get; set; } = Domain.Enum.UserRole.User.ToString();
}