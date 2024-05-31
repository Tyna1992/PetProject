using Microsoft.EntityFrameworkCore;
using VineyardSite.Data;
using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserById(string id)
    {
        var user = await _context.Users.FindAsync(id);
        return user;
    }

    public async Task<User> GetByUsername(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.UserName == username);
        return user;
    }
    
    public async Task<User> GetByEmail(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
        return user;
    }
    
    public async Task UpdateUser(string id, User user)
    {
        var userToUpdate = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
        if (userToUpdate != null)
        {
            userToUpdate.UserName = user.UserName;
            userToUpdate.Email = user.Email;
            userToUpdate.Address = user.Address;
            _context.Users.Update(userToUpdate);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task DeleteUser(string id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}