using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VineyardSite.Model;
using VineyardSite.Service.Repositories;

namespace VineyardSite.Controllers;
[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IWineVariantRepository _wineVariantRepository;
    private readonly IWineRepository _wineRepository;
    private ILogger<InventoryController> _logger;
    
    public InventoryController(IInventoryRepository inventoryRepository,
        IWineVariantRepository wineVariantRepository, ILogger<InventoryController> logger,IWineRepository wineRepository)
    {
        _inventoryRepository = inventoryRepository;
        _wineVariantRepository = wineVariantRepository;
        _logger = logger;
        _wineRepository = wineRepository;
    }
    
    [HttpPost("AddInventory/{name}/{year}/{quantity}/{alcohol}"), Authorize(Roles="Admin")]
    public async Task<IActionResult> AddInventory(string name, int year,double alcohol,int quantity =1 )
    {
        var wine = await _wineRepository.GetWineByName(name);
        if (wine == null)
        {
            return NotFound("No wine found with that name in catalog");
        }
        var variant = await _wineVariantRepository.GetVariantByYear(year, name, alcohol);
        
        if (variant == null)
        {
            return NotFound("No vintage found !");
        }
        
        if (quantity < 0)
        {
            return StatusCode(406, "Invalid quantity");
        }
        
        var existingInventoryItem = await _inventoryRepository.IsItemInInventory(variant.Id);
        if(existingInventoryItem != null)
        {
            try
            {
                await _inventoryRepository.AddStock(existingInventoryItem.Id, quantity);
                return Ok(existingInventoryItem);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }
        
        
        var inventoryItem = new InventoryItem
        {
            WineVersion = variant,
            WineVariantId = variant.Id,
            Quantity = quantity
        };
        try
        {
            await _inventoryRepository.AddInventoryItem(inventoryItem);
            return Ok(inventoryItem);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding inventory item");
            return StatusCode(500);
        }
        
        
      
        
    }
    
    [HttpGet("GetInventory")]
    public async Task<IActionResult> GetInventory()
    {
        try
        {
            var inventory = await _inventoryRepository.GetStock();
            if(!inventory.Any())
            {
                return NotFound("Inventory is empty!");
            }

            return Ok(inventory);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting inventory");
            return StatusCode(500);
        }
    }
    
}