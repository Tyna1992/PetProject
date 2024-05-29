using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public interface ICartRepository
{
    Task<IEnumerable<Cart>> GetAllCarts(); 
    Task<Cart> GetCart(int id);
    Task AddCart(Cart cart);
    Task RemoveCart(int id);
    Task UpdateCart(int id, Cart cart);
    
}