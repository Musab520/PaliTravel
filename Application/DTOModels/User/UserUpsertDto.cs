namespace Application.DTOModels.User;

public class UserUpsertDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}