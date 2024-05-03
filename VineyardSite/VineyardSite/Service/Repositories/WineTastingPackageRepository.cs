using Microsoft.EntityFrameworkCore;
using VineyardSite.Data;
using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public class WineTastingPackageRepository : IWineTastingRepository
{
    private readonly DataContext _context;
    
    public WineTastingPackageRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<WineTastingPackage>> GetAllWineTastingPackages()
    {
        return await _context.WineTastingPackages.ToListAsync();
    }
    
    public async Task<WineTastingPackage> GetWineTastingPackageById(int id)
    {
        var wineTastingPackage = await _context.WineTastingPackages.FindAsync(id);
        return wineTastingPackage;
    }
    
    public async Task AddWineTastingPackage(WineTastingPackage wineTastingPackage)
    {
        _context.WineTastingPackages.Add(wineTastingPackage);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateWineTastingPackage(int id, WineTastingPackage wineTastingPackage)
    {
        var wineTastingPackageToUpdate = await _context.WineTastingPackages.FindAsync(id);
        if (wineTastingPackageToUpdate != null)
        {
            wineTastingPackageToUpdate.Name = wineTastingPackage.Name;
            wineTastingPackageToUpdate.Price = wineTastingPackage.Price;
            wineTastingPackageToUpdate.Description = wineTastingPackage.Description;
            
            _context.WineTastingPackages.Update(wineTastingPackageToUpdate);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task DeleteWineTastingPackage(int id)
    {
        var wineTastingPackage = await _context.WineTastingPackages.FindAsync(id);
        if (wineTastingPackage != null)
        {
            _context.WineTastingPackages.Remove(wineTastingPackage);
            await _context.SaveChangesAsync();
        }
    }
}