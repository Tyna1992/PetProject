using Microsoft.EntityFrameworkCore;
using VineyardSite.Data;
using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public class CartItemRepository : ICartItemRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IWineVariantRepository _wineVariantRepository;
    
    public CartItemRepository(ApplicationDbContext context, IWineVariantRepository wineVariantRepository)
    {
        _context = context;
        _wineVariantRepository = wineVariantRepository;
    }
   
    
    public async Task AddCartItemAsync(int drinkId, int quantity, int cartId)
    {
        var wineVariant = await _wineVariantRepository.GetWineVariant(drinkId);
        _context.CartItems.Add(new CartItem
        {
            CartId = cartId,
            WineVariantId = drinkId,
            WineVersion = wineVariant,
            Quantity = quantity
        });
        await _context.SaveChangesAsync();
    }
    

    public async Task<CartItem> GetCartItemAsync(int cartItemId)
    {
        return await _context.CartItems.FirstOrDefaultAsync(cartItem => cartItem.Id == cartItemId);
    }

    public async Task<IEnumerable<CartItem>> GetCartItemsAsync(int cartId)
    {
        return await _context.CartItems.Where(cartItem => cartItem.CartId == cartId).ToListAsync();
    }

    public async Task RemoveCartItemAsync(int cartItemId)
    {
        var cartItem = await _context.CartItems.FirstOrDefaultAsync(cartItem => cartItem.Id == cartItemId);
        if (cartItem != null)
        {
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateCartItemAsync(CartItem cartItem)
    {
        var cartItemToUpdate = await _context.CartItems.FirstOrDefaultAsync(cartItem => cartItem.Id == cartItem.Id);
        if (cartItemToUpdate != null)
        {
            cartItemToUpdate.Quantity = cartItem.Quantity;
            _context.CartItems.Update(cartItemToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}