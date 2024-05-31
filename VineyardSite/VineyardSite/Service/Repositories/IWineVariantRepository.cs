using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public interface IWineVariantRepository
{
    Task<IEnumerable<WineVariant>> GetAllWineVariants();
    Task<WineVariant> GetWineVariant(int id);
    Task AddWineVariant(WineVariant wineVariant);
    Task DeleteWineVariant(int id);
    Task UpdateWineVariant(int id,WineVariant wineVariant);
    Task<WineVariant> GetVariantByYear(int year,string name, double alcoholContent);

}