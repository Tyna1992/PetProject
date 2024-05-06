using System.IdentityModel.Tokens.Jwt;

namespace VineyardSite.Service.Authentication;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(string email, string username, string password,string address, string role);
    Task<AuthResult> LoginAsync(string userName, string password);
    JwtSecurityToken Verify(string token);
    
}