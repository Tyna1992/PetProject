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
    
    [HttpPost]
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
    
}