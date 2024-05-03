using Microsoft.EntityFrameworkCore;
using VineyardSite.Data;
using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public class WineRepository : IWineRepository
{
    private readonly DataContext _context;
    
    public WineRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Wine>> GetAllWine()
    {
        return await _context.Wines.ToListAsync();
        
    }

    public async Task<Wine> GetWineById(int id)
    {
        var wine = await _context.Wines.FindAsync(id);
        return wine;
    }

    public async Task AddWine(Wine wine)
    {
        _context.Wines.Add(wine);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateWine(int id, Wine wine)
    {
        var wineToUpdate = await _context.Wines.FirstOrDefaultAsync(wine => wine.Id == id);
        if (wineToUpdate != null)
        {
            wineToUpdate.Name = wine.Name;
            wineToUpdate.Price = wine.Price;
            wineToUpdate.Description = wine.Description;
            wineToUpdate.AlcoholContent = wine.AlcoholContent;
            wineToUpdate.Type = wine.Type;
            
            _context.Wines.Update(wineToUpdate);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteWine(int id)
    {
        var wine = await _context.Wines.FirstOrDefaultAsync(wine => wine.Id == id);
        if (wine != null)
        {
            _context.Wines.Remove(wine);
            await _context.SaveChangesAsync();
        }
    }
}