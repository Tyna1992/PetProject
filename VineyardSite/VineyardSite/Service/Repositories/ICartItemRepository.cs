using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public interface ICartItemRepository
{
    Task AddCartItemAsync(int drinkId, int quantity, int cartId);
    Task<CartItem> GetCartItemAsync(int cartItemId);
    Task<IEnumerable<CartItem>> GetCartItemsAsync(int cartId);
    Task RemoveCartItemAsync(int cartItemId);
    Task UpdateCartItemAsync(CartItem cartItem);
    
}