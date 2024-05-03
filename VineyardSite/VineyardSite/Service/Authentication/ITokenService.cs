using VineyardSite.Model;

namespace VineyardSite.Service.Authentication;

public interface ITokenService
{
    string CreateToken(User user, string role);
}