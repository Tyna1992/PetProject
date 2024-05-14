using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public interface IWineRepository
{
    Task<IEnumerable<Wine>> GetAllWine();
    Task<Wine?> GetWineByName(string name);
    Task AddWine(Wine wine);
    Task UpdateWine(int id, Wine wine);
    Task DeleteWine(int id);
}