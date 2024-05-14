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

    [HttpPost("AddWine"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddWine([FromBody] Wine wine)
    {
        try
        {
            await _wineRepository.AddWine(wine);
            return Ok(wine);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("GetAllWine"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllWine()
    {
        try
        {
            var wines = await _wineRepository.GetAllWine();
            return Ok(wines);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
    [HttpDelete("DeleteWine/{id}"), Authorize(Roles= "Admin")]
    public async Task<IActionResult> DeleteWine(int id)
    {
        try
        {
            await _wineRepository.DeleteWine(id);
            return Ok();
        }
        catch (Exception e)
        {
            
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut("UpdateWine/{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateWine(int id, [FromBody] Wine wine)
    {
        try
        {
            await _wineRepository.UpdateWine(id, wine);
            return Ok(wine);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
}