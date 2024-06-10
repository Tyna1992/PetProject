using VineyardSite.Model;

namespace VineyardSite.Service.Repositories.Profile;

public interface IAddressRepository
{
    Task AddAddressToUser(string userId, Address address);
    Task<Address> GetAddress(string userId);
    Task UpdateAddress(string userId, Address address);
}