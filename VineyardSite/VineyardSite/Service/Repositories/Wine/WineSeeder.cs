using VineyardSite.Data;
using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public class WineSeeder : IWineSeeder
{
    private readonly ApplicationDbContext _context;
    
    public WineSeeder(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SeedWine()
    {
        Console.WriteLine("Seeding wines...");
        if (!_context.WineVariants.Any() && !_context.Wines.Any())
        {
            var wines = new[]
            {
                new Wine { Name = "Chardonnay", Type = "White", Sweetness = "Dry", Description = "A popular white wine" },
                new Wine { Name = "Merlot", Type = "Red", Sweetness = "Medium", Description = "A soft and smooth red wine" }
            };

            _context.Wines.AddRange(wines);
            await _context.SaveChangesAsync();

            var wineVariants = new[]
            {
                new WineVariant { WineId = wines[0].Id, Year = 2021, Price = 20.0, AlcoholContent = 13.5 },
                new WineVariant { WineId = wines[0].Id, Year = 2020, Price = 18.0, AlcoholContent = 13.0 },
                new WineVariant { WineId = wines[1].Id, Year = 2020, Price = 15.0, AlcoholContent = 12.0 },
                new WineVariant { WineId = wines[1].Id, Year = 2019, Price = 14.0, AlcoholContent = 11.5 }
            };

            _context.WineVariants.AddRange(wineVariants);
            await _context.SaveChangesAsync();

            Console.WriteLine("Wines seeded successfully");
        }
    }
}