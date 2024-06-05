using HealthManagerServer.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VineyardSite.Contracts;
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
    
    public async Task<User> UpdateUser(string id, UserDetailResponse userDetailResponse)
    {
        var userToUpdate = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
        if (userToUpdate != null)
        {
            userToUpdate.Email = userDetailResponse.Email;
            userToUpdate.Address = userDetailResponse.Address;
            userToUpdate.PhoneNumber = userDetailResponse.PhoneNumber;
            _context.Users.Update(userToUpdate);
            await _context.SaveChangesAsync();
        }
        return userToUpdate;
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
    
    public async Task<User> ChangePassword(string id, PasswordChangeResponse passwordChangeResponse)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
        if (user != null)
        {
            var hasher = new PasswordHasher<User>();
            var verificationResult = hasher.VerifyHashedPassword(user, user.PasswordHash, passwordChangeResponse.OldPassword);

            if (verificationResult == PasswordVerificationResult.Success)
            {
                user.PasswordHash = hasher.HashPassword(user, passwordChangeResponse.NewPassword);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            } else
            {
                throw new Exception("Incorrect password");
            }
        }
        return user;
    }
}