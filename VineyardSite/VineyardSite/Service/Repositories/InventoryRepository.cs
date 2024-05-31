using Microsoft.EntityFrameworkCore;
using VineyardSite.Data;
using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private readonly DataContext _context;
    
    public InventoryRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task AddInventoryItem(InventoryItem inventoryItem)
    {
        _context.Inventory.Add(inventoryItem);
        await _context.SaveChangesAsync();
    
    }

    public async Task<IEnumerable<InventoryItem>> GetAllInventoryItems()
    {
        return await _context.Inventory.ToListAsync();
    }

    public async Task<IEnumerable<Stock>> GetStock()
    {
        return await _context.Inventory.Select(inventoryItem => new Stock
        {
            Name = inventoryItem.WineVersion.Wine.Name,
            Year = inventoryItem.WineVersion.Year,
            Price = inventoryItem.WineVersion.Price,
            AlcoholContent = inventoryItem.WineVersion.AlcoholContent,
            Quantity = inventoryItem.Quantity
        }).ToListAsync();
    }
    public async Task<InventoryItem?> GetInventoryItem(int id)
    {
        return await _context.Inventory.FirstOrDefaultAsync(inventoryItem => inventoryItem.Id == id);
    }

    public async Task AddStock(int id, int quantity)
    {
        var inventoryItem = await _context.Inventory.FirstOrDefaultAsync(inventoryItem => inventoryItem.Id == id);
        if (inventoryItem != null)
        {
            inventoryItem.Quantity += quantity;
            _context.Inventory.Update(inventoryItem);
            await _context.SaveChangesAsync();
        }
    }

    public async Task RemoveStock(int id, int quantity)
    {
        var inventoryItem = await _context.Inventory.FirstOrDefaultAsync(inventoryItem => inventoryItem.Id == id);
        if (inventoryItem != null)
        {
            inventoryItem.Quantity -= quantity;
            _context.Inventory.Update(inventoryItem);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteInventoryItem(int id)
    {
        var inventoryItem = await _context.Inventory.FirstOrDefaultAsync(inventoryItem => inventoryItem.Id == id);
        if (inventoryItem != null)
        {
            _context.Inventory.Remove(inventoryItem);
            await _context.SaveChangesAsync();
        }
    }
}