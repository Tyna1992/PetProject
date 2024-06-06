using VineyardSite.Contracts;
using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUserById(string id);
    Task<User> GetByEmail(string email);
    Task<User> UpdateUser(string id, UserDetailResponse userDetailResponse);
    Task DeleteUser(string id);
    Task<User> GetByUsername(string username);
    Task<User> ChangePassword(string id, PasswordChangeResponse passwordChangeResponse);
    
}