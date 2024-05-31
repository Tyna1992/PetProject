using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VineyardSite.Data;
using VineyardSite.Model;

namespace VineyardSite.Service.Authentication;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;
    private readonly IConfiguration _configuration;
    private readonly ApplicationDbContext _context;
    
    
    public AuthService(UserManager<User> userManager, ITokenService tokenService, IConfiguration configuration, ApplicationDbContext context)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _configuration = configuration;
        _context = context;
    }
    public async Task<AuthResult> RegisterAsync(string email, string username, string password, string address, string role)
    {
        var existingUser = await _userManager.FindByEmailAsync(email);
        
        if (existingUser != null)
        {
            return FailedRegistration(IdentityResult.Failed(new IdentityError { Code = "EmailExists", Description = "Email already exists" }), email, username);

        }
        var user = new User {UserName = username, Email = email, Address = address};
        
        
        var result = await _userManager.CreateAsync(user, password);
        
        if (!result.Succeeded)
        {
            return FailedRegistration(result, email, username);
        }
        
        var cart = new Cart { User = user, UserId = user.Id };
        _context.Carts.Add(cart);
        await _context.SaveChangesAsync();
        user.Cart = cart;
        user.CartId = cart.CartId;
        
        await _userManager.AddToRoleAsync(user, role);
        return new AuthResult(true, email, username, "");
    }

    public async Task<AuthResult> LoginAsync(string userName, string password)
    {
        var managedUser = await _userManager.FindByNameAsync(userName);

        if (managedUser == null)
        {
            return InvalidUsername(userName);
        }
        
        
        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, password);
        if (!isPasswordValid)
        {
            return InvalidPassword(userName, managedUser.UserName);
        }

        var roles = await _userManager.GetRolesAsync(managedUser);
        var accessToken = _tokenService.CreateToken(managedUser, roles[0]);
        Console.WriteLine(accessToken);
        return new AuthResult(true, managedUser.Email, managedUser.UserName, accessToken);
    }

    public JwtSecurityToken Verify(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration.GetSection("IssuerSigningKey").Value);
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
        }, out SecurityToken validatedToken);
        return (JwtSecurityToken)validatedToken;
    }
    
    private static AuthResult InvalidUsername(string username)
    {
        var result = new AuthResult(false, "", username, "");
        result.ErrorMessages.Add("Bad credentials", "Invalid username");
        return result;
    }

    private static AuthResult InvalidPassword(string email, string userName)
    {
        var result = new AuthResult(false, email, userName, "");
        result.ErrorMessages.Add("Bad credentials", "Invalid password");
        return result;
    }
    private static AuthResult FailedRegistration(IdentityResult result, string email, string username)
    {
        var authResult = new AuthResult(false, email, username, "");

        foreach (var error in result.Errors)
        {
            authResult.ErrorMessages.Add(error.Code, error.Description);
        }

        return authResult;
    }
}