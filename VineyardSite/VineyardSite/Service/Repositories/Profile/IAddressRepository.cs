using VineyardSite.Model;
using VineyardSite.Model.Address;

namespace VineyardSite.Service.Repositories.Profile;

public interface IAddressRepository
{
    Task AddAddressToUser(string userId, Address address);
    Task<PrimaryAddress> GetPrimaryAddress(string userId);
    Task UpdateAddress(int addressId, Address address);
    Task<ICollection<Address>> GetAllAddress(string userId);
    Task DeleteAddress(int addressId);
}