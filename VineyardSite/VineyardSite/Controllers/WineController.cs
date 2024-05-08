using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VineyardSite.Model;
using VineyardSite.Service.Repositories;

namespace VineyardSite.Controllers;
[ApiController]
[Route("api/[controller]")]

public class WineController : ControllerBase
{
    private readonly IWineRepository _wineRepository;
    
    public WineController(IWineRepository wineRepository)
    {
        _wineRepository = wineRepository;
    }

    [HttpPost("/wine/AddWine"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddWine([FromBody] Wine wine)
    {
        await _wineRepository.AddWine(wine);
        return Ok(wine);
    }
    
    
}