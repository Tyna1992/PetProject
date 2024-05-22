
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VineyardSite.Model;
using VineyardSite.Service.Repositories;
using System.Text.Json;

namespace VineyardSite.Controllers;
[ApiController]
[Route("api/[controller]")]
public class VariantController : ControllerBase
{
    private readonly IWineVariantRepository _wineVariantRepository;
    private readonly IWineRepository _wineRepository;
    private ILogger<VariantController> _logger;
    
    public VariantController(IWineVariantRepository wineVariantRepository, ILogger<VariantController> logger, IWineRepository wineRepository)
    {
        _wineVariantRepository = wineVariantRepository;
        _logger = logger;
        _wineRepository = wineRepository;
    }

    [HttpPost("AddWineVariant/{name}/{price}/{alcohol}/{year}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddVariant(string name, double price,  double alcohol ,int year)
    {
        
        var wine = await _wineRepository.GetWineByName(name);
        if (wine == null)
        {
            return NotFound("No wine found with that name in catalog");
        }
        
        
        var variant = new WineVariant
        {
            Wine = wine,
            WineId = wine.Id,
            Price = price,
            AlcoholContent = alcohol ,
            Year = year
        };
        try
        {
            await _wineVariantRepository.AddWineVariant(variant);
            return Ok(variant);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding wine variant");
            return StatusCode(500);
        }
        
    }
}