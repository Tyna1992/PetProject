using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public interface ISnackRepository
{
    Task<IEnumerable<Snack>> GetAllSnacks();
    Task<Snack?> GetSnackById(int? id);
    Task AddSnack(Snack snack);
    Task UpdateSnack(int id, Snack snack);
    Task DeleteSnack(int id);
    
}