using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public interface IWineTastingRepository
{
    Task<IEnumerable<WineTastingPackage>> GetAllWineTastingPackages();
    Task<WineTastingPackage> GetWineTastingPackageById(int id);
    Task AddWineTastingPackage(WineTastingPackage wineTastingPackage);
    Task UpdateWineTastingPackage(int id, WineTastingPackage wineTastingPackage);
    Task DeleteWineTastingPackage(int id);
}