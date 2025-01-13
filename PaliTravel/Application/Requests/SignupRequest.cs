namespace PaliTravel.Application.Requests;

public class SignupRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}