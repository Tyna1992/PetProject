using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllOrders();
    Task<Order> GetOrderById(string id);
    Task AddOrder(Order order);
    Task UpdateOrder(string id, Order order);
    Task DeleteOrder(string id);
}