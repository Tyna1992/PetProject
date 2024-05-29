using Microsoft.EntityFrameworkCore;
using VineyardSite.Data;
using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;
    
    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
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
    
    public async Task AddOrder(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateOrder(string id, Order order)
    {
        var orderToUpdate = await _context.Orders.FirstOrDefaultAsync(order => order.Id.ToString() == id);
        if (orderToUpdate != null)
        {
            orderToUpdate.Date = order.Date;
            orderToUpdate.TotalPrice = order.TotalPrice;
            orderToUpdate.User = order.User;
            orderToUpdate.WineVariant = order.WineVariant;
            orderToUpdate.Address = order.Address;
            orderToUpdate.Quantity = order.Quantity;
            orderToUpdate.DeliveryType = order.DeliveryType;
            orderToUpdate.PaymentType = order.PaymentType;
            orderToUpdate.Status = order.Status;
            orderToUpdate.Notes = order.Notes;
            orderToUpdate.Email = order.Email;
            _context.Orders.Update(orderToUpdate);
            await _context.SaveChangesAsync();
        }
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