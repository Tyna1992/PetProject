using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllOrders();
    Task<Order> GetOrderById(string id);
    Task<Order> AddOrder(string userId, OrderRequest orderRequest);
    Task<ICollection<Order>> GetOrdersByUserId(string userId);
    
    Task DeleteOrder(string id);
}