using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public interface IInventoryRepository
{
    Task AddInventoryItem(InventoryItem inventoryItem);
    Task<IEnumerable<InventoryItem>> GetAllInventoryItems();
    Task<InventoryItem?> GetInventoryItem(int id);
    Task AddStock(int id, int quantity);
    Task RemoveStock(int id, int quantity);
    Task DeleteInventoryItem(int id);
}