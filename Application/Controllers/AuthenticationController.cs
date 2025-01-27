using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.IService;
using Application.Requests;
using Application.Responses;
using Domain.SieveModel;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Application.Controllers;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;
    private readonly IValidator<UserModel> _validator;
    private readonly IPasswordHasher<UserModel> _passwordHasher;

    public AuthenticationController(IUserService userService, IConfiguration configuration, IValidator<UserModel> validator, IPasswordHasher<UserModel> passwordHasher)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _validator = validator;
        _passwordHasher = passwordHasher;
    }
    
    [HttpPost("signup")]
    public async Task<ActionResult<Boolean>> SignUp(SignupRequest signupRequest)
    {
        var user = await ValidateUserCredentials(signupRequest.Email, signupRequest.Password);
        if(user != null)
        {
            return Conflict("A user already exists with the specified email");
        } else {
            UserModel newUser = new UserModel();
            newUser.Email = signupRequest.Email;
            newUser.FirstName = signupRequest.FirstName;
            newUser.LastName = signupRequest.LastName ?? "";
            if (signupRequest.Password != null) {
                newUser.PasswordHash = _passwordHasher.HashPassword(newUser, signupRequest.Password);
            }
            ValidationResult validationResult = _validator.Validate(newUser);
            SignUpResponse signUpResponse = new SignUpResponse();
            if (validationResult.IsValid)
            {
                _userService.Insert(newUser);
                signUpResponse.Success = true;
                return Ok(signUpResponse);
            } else
            {
                signUpResponse.Success = false;
                return BadRequest(signUpResponse);
            }
        }
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<Boolean>> Login(AuthenticationRequest authenticationRequest)
    {
        UserModel? user = await ValidateUserCredentials(authenticationRequest.Email, authenticationRequest.Password);
        if(user == null)
        {
            return Unauthorized("User Not Found");
        }
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
        var signingCredential = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim("sub", user.Id.ToString()));
        if (user.FirstName != null && user.LastName != null)
        {
            claimsForToken.Add(new Claim("First_Name", user.FirstName.ToString()));
            claimsForToken.Add(new Claim("Last_Name", user.LastName.ToString()));
        }

        var jwtSecurityToken = new JwtSecurityToken(_configuration["Authentication:Issuer"], _configuration["Authentication:Audience"], claimsForToken, DateTime.UtcNow, DateTime.UtcNow.AddHours(1), signingCredential);
        var tokentoReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        return Ok(tokentoReturn);
    }
    
    private async Task<UserModel?> ValidateUserCredentials(string? email, string? password)
    {
        if (password == null || email == null)
        {
            return null;
        }
        UserModel? user = await _userService.GetByEmail(email);
        if (user == null)
        {
            return null;
        }
        PasswordVerificationResult passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        if (passwordVerificationResult == PasswordVerificationResult.Success)
        {
            return user;
        }
        else
        {
            return null;
        }
    }
}