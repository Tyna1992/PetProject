using Microsoft.EntityFrameworkCore;
using VineyardSite.Data;
using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public class CartRepository : ICartRepository
{
    private readonly ApplicationDbContext _dataContext;
   
    
    public CartRepository( ApplicationDbContext context)
    {
        
        _dataContext = context;
    }
    
    public async Task<IEnumerable<Cart>> GetAllCarts()
    {
        return await _dataContext.Carts.ToListAsync();
    }

    public async Task<Cart> GetCart(int id)
    {
        return await _dataContext.Carts.FirstOrDefaultAsync(cart => cart.CartId == id);
    }

    public async Task AddCart(Cart cart)
    {
        _dataContext.Carts.Add(cart);
        await _dataContext.SaveChangesAsync();
    }

    public async Task RemoveCart(int id)
    {
        var cart = await _dataContext.Carts.FirstOrDefaultAsync(cart => cart.CartId == id);
        if (cart != null)
        {
            _dataContext.Carts.Remove(cart);
            await _dataContext.SaveChangesAsync();
        }
    }

    public async Task UpdateCart(int id, Cart cart)
    {
        var cartToUpdate = await _dataContext.Carts.FirstOrDefaultAsync(cart => cart.CartId == id);
        if (cartToUpdate != null)
        {
            cartToUpdate.CartItems = cart.CartItems;
            await _dataContext.SaveChangesAsync();
        }
    }
}