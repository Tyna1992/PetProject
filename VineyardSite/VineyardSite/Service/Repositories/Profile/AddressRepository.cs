using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VineyardSite.Data;
using VineyardSite.Model;
using VineyardSite.Model.Address;

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
    
    public async Task<PrimaryAddress> GetPrimaryAddress(string userId)
    {
        var user = await _dataContext.Users.Include(user => user.PrimaryAddress).FirstOrDefaultAsync(user => user.Id == userId);
        return user?.PrimaryAddress;
    }
    public async Task UpdateAddress(int addressId, [FromBody] Address address)
    {
        var addressToUpdate = await _dataContext.Addresses.FirstOrDefaultAsync(address => address.AddressId == addressId);
        if (addressToUpdate != null)
        {
            addressToUpdate.Street = address.Street;
            addressToUpdate.HouseNumber = address.HouseNumber;
            addressToUpdate.ZipCode = address.ZipCode;
            addressToUpdate.City = address.City;
            addressToUpdate.Country = address.Country;
            
            _dataContext.Addresses.Update(addressToUpdate);
            await _dataContext.SaveChangesAsync();
        }
    }
    public async Task DeleteAddress(int addressId)
    {
        var addressToDelete = await _dataContext.Addresses.FirstOrDefaultAsync(address => address.AddressId == addressId);
        if (addressToDelete != null)
        {
            _dataContext.Addresses.Remove(addressToDelete);
            await _dataContext.SaveChangesAsync();
        }
    }

    public async Task<ICollection<Address>> GetAllAddress(string userId)
    {
        var user = await _dataContext.Users.Include(user => user.Addresses).FirstOrDefaultAsync(user => user.Id == userId);
        return user.Addresses;
    }

}