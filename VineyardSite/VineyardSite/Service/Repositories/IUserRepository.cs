using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUserById(string id);
    Task<User> GetByEmail(string email);
    Task UpdateUser(string id, User user);
    Task DeleteUser(string id);
    
}