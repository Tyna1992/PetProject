using System.IdentityModel.Tokens.Jwt;
using VineyardSite.Model;

namespace VineyardSite.Service.Authentication;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(string email, string username, string password, string role);
    Task<AuthResult> LoginAsync(string userName, string password);
    JwtSecurityToken Verify(string token);
    
}