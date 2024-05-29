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
        throw new NotImplementedException();
    }

    public async Task AddCart(Cart cart)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveCart(int id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateCart(int id, Cart cart)
    {
        throw new NotImplementedException();
    }
}