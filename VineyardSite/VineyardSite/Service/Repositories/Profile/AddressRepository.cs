using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VineyardSite.Data;
using VineyardSite.Model;

namespace VineyardSite.Service.Repositories.Profile;

public class AddressRepository : IAddressRepository
{
    private readonly ApplicationDbContext _dataContext;
    
    public AddressRepository(ApplicationDbContext context)
    {
        _dataContext = context;
    }
    
    public async Task AddAddressToUser(string userId, [FromBody] Address address)
    {
        var user = await _dataContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
        if (user != null)
        {
            address.UserId = userId;
            _dataContext.Addresses.Add(address);
            await _dataContext.SaveChangesAsync();
        }
    }
    
    public async Task<Address> GetAddress(string userId)
    {
        var user = await _dataContext.Users.Include(user => user.Address).FirstOrDefaultAsync(user => user.Id == userId);
        return user?.Address;
    }
    
    public async Task UpdateAddress(string userId, [FromBody] Address address)
    {
        var user = await _dataContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
        if (user != null)
        {
            user.Address = address;
            await _dataContext.SaveChangesAsync();
        }
    }
}