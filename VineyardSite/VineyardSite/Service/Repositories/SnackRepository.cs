using Microsoft.EntityFrameworkCore;
using VineyardSite.Data;
using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public class SnackRepository : ISnackRepository
{
    private readonly DataContext _context;
    
    public SnackRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Snack>> GetAllSnacks()
    {
        return await _context.Snacks.ToListAsync();
    }

    public async Task<Snack> GetSnackById(int id)
    {
        var snack = await _context.Snacks.FindAsync(id);
        return snack;
    }

    public async Task AddSnack(Snack snack)
    {
        _context.Snacks.Add(snack);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSnack(int id, Snack snack)
    {
        var snackToUpdate = await _context.Snacks.FirstOrDefaultAsync(snack => snack.Id == id);
        if (snackToUpdate != null)
        {
            snackToUpdate.Name = snack.Name;
            snackToUpdate.Price = snack.Price;
            snackToUpdate.Description = snack.Description;
            _context.Snacks.Update(snackToUpdate);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteSnack(int id)
    {
        var snack = await _context.Snacks.FirstOrDefaultAsync(snack => snack.Id == id);
        if (snack != null)
        {
            _context.Snacks.Remove(snack);
            await _context.SaveChangesAsync();
        }
    }
}