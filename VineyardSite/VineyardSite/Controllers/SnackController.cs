using Microsoft.AspNetCore.Mvc;
using VineyardSite.Model;
using VineyardSite.Service.Repositories;

namespace VineyardSite.Controllers;


[ApiController]
[Route("api/[controller]")]
public class SnackController : ControllerBase
{
    private readonly ISnackRepository _snackRepository;
    
    public SnackController(ISnackRepository snackRepository)
    {
        _snackRepository = snackRepository;
    }
    
    [HttpPost("/snack/AddSnack")]
    public async Task<IActionResult> AddSnack([FromBody]Snack snack)
    {
        try
        {
            await _snackRepository.AddSnack(snack);
            return Ok(snack);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete("/snack/DeleteSnack/{id:int}")]
    public async Task<IActionResult> DeleteSnack(int id)
    {
        try
        {
            await _snackRepository.DeleteSnack(id);
            return Ok("Snack deleted");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("/snack/GetSnackById/{id:int}")]
    public async Task<IActionResult> GetSnackById(int id)
    {
        try
        {
            var snack = await _snackRepository.GetSnackById(id);
            return Ok(snack);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("/snack/GetAllSnacks")]
    public async Task<IActionResult> GetAllSnacks()
    {
        try
        {
            var snacks = await _snackRepository.GetAllSnacks();
            return Ok(snacks);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}