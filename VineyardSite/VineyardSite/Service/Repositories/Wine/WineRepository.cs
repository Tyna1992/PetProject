using Microsoft.EntityFrameworkCore;
using VineyardSite.Data;
using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public class WineRepository : IWineRepository
{
    private readonly ApplicationDbContext _context;
    
    public WineRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Wine>> GetAllWine()
    {
        return await _context.Wines.ToListAsync();
        
    }

    public async Task<Wine?> GetWineByName(string name)
    {
        
        var wine = await _context.Wines.FirstOrDefaultAsync(wine => wine.Name == name);
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
            wineToUpdate.Description = wine.Description;
            wineToUpdate.Type = wine.Type;
            wineToUpdate.Sweetness = wine.Sweetness;
            
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