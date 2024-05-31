﻿using Microsoft.EntityFrameworkCore;
using VineyardSite.Data;
using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public class WineVariantRepository : IWineVariantRepository
{
    private readonly ApplicationDbContext _context;
    
    public WineVariantRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<WineVariant>> GetAllWineVariants()
    {
        return await _context.WineVariants.ToListAsync();
    }

    public async Task<WineVariant> GetVariantByYear(int year,string name, double alcoholContent)
    {
        return await _context.WineVariants.FirstOrDefaultAsync(wineVariant =>
            wineVariant.Year == year && wineVariant.Wine.Name == name && wineVariant.AlcoholContent == alcoholContent);
    }
    
    public async Task<WineVariant> GetWineVariant(int id)
    {
        return await _context.WineVariants.FirstOrDefaultAsync(wineVariant => wineVariant.Id == id);
    }

    public async Task AddWineVariant(WineVariant wineVariant)
    {
        _context.WineVariants.Add(wineVariant);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteWineVariant(int id)
    {
        var wineVariant = await _context.WineVariants.FirstOrDefaultAsync(wineVariant => wineVariant.Id == id);
        if (wineVariant != null)
        {
            _context.WineVariants.Remove(wineVariant);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateWineVariant(int id, WineVariant wineVariant)
    {
        var wineVariantToUpdate = await _context.WineVariants.FirstOrDefaultAsync(wineVariant => wineVariant.Id == id);
        if (wineVariantToUpdate != null)
        {
            
            wineVariantToUpdate.Price = wineVariant.Price;
            wineVariantToUpdate.AlcoholContent = wineVariant.AlcoholContent;
            wineVariantToUpdate.Year = wineVariant.Year;
            
            
            _context.WineVariants.Update(wineVariantToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}