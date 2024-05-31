using Microsoft.EntityFrameworkCore;
using VineyardSite.Data;
using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IInventoryRepository _inventoryRepository;
    
    public OrderRepository(ApplicationDbContext context, IInventoryRepository inventoryRepository)
    {
        _context = context;
        _inventoryRepository = inventoryRepository;
    }
    
    
    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        return await _context.Orders.ToListAsync();
    }
    
    public async Task<Order> GetOrderById(string id)
    {
        var order = await _context.Orders.FindAsync(id);
        return order;
    }
    
    public async Task<Order> AddOrder(string userId, OrderRequest orderRequest)
    {
       
        // Get the user's cart
        var cart = await _context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(ci => ci.WineVersion).Include(cart => cart.User)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        var inventory = await _inventoryRepository.GetAllInventoryItems();
        // Create a new order
        var order = new Order
        {
            User = cart.User,
            UserId = cart.UserId,
            Date = DateTime.Now,
            TotalPrice = cart.CartItems.Sum(ci => ci.WineVersion.Price * ci.Quantity),
            Status = "Placed",
            OrderItems = new List<OrderItem>(),
            Email = cart.User.Email,
            Address = cart.User.Address,
            DeliveryType = orderRequest.DeliveryType,
            PaymentType = orderRequest.PaymentType,
            Notes = orderRequest.Notes
            
        };

        // Copy cart items to order items
        foreach (var cartItem in cart.CartItems)
        {
            var orderItem = new OrderItem
            {
                Quantity = cartItem.Quantity,
                WineVariant = cartItem.WineVersion,
                WineVariantId = cartItem.WineVariantId,
                Order = order,
                OrderId = order.Id
            };
           if(orderItem.Quantity < inventory.FirstOrDefault(i => i.WineVariantId == orderItem.WineVariantId)?.Quantity)
            {
                inventory.FirstOrDefault(i => i.WineVariantId == orderItem.WineVariantId).Quantity -= orderItem.Quantity;
                _context.Inventory.Update(inventory.FirstOrDefault(i => i.WineVariantId == orderItem.WineVariantId));
                order.OrderItems.Add(orderItem);
            }
            else
            {
                throw new Exception("Not enough stock");
            }
        }
        
        
        // Save the order
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        
        

        // Clear the cart
        _context.CartItems.RemoveRange(cart.CartItems);
        await _context.SaveChangesAsync();
        
        return order;
    }
    
    
    public async Task DeleteOrder(string id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(order => order.Id.ToString() == id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}