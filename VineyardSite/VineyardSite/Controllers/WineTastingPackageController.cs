using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VineyardSite.Model;
using VineyardSite.Service.Repositories;

namespace VineyardSite.Controllers;
[ApiController]
[Route("api/[controller]")]
public class WineTastingController : ControllerBase
{
    private readonly IWineTastingRepository _wineTastingRepository;
    private readonly IWineRepository _wineRepository;
    
    private readonly ISnackRepository _snackRepository;
    
    public WineTastingController(IWineTastingRepository wineTastingRepository, IWineRepository wineRepository, ISnackRepository snackRepository)
    {
        _wineTastingRepository = wineTastingRepository;
        _wineRepository = wineRepository;
        
        _snackRepository = snackRepository;
    }

    [HttpPost("/wineTasting/AddPackage"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddPackage(string name, string description, double price,int wineId,int? snackId, int? wine2Id, int? wine3Id, int? wine4Id)
    {
       
            var wine = await _wineRepository.GetWineById(wineId);
            if(wine == null)
            {
                return NotFound("Wine not found");
            }
            var wine2 = await _wineRepository.GetWineById(wine2Id);
            
            var wine3 = await _wineRepository.GetWineById(wine3Id);
           
            var wine4 = await _wineRepository.GetWineById(wine4Id);
          
            var snack = await _snackRepository.GetSnackById(snackId);
            
            var package = new WineTastingPackage
            {
                Name = name,
                Description = description,
                Price = price,
                Wine1 = wine,
                Wine1Id = wine.Id,
                Wine2 = wine2,
                Wine2Id = wine2?.Id,
                Wine3 = wine3,
                Wine3Id = wine3?.Id,
                Wine4 = wine4,
                Wine4Id = wine4?.Id,
                Snack = snack,
                SnackId = snack?.Id
            };
            await _wineTastingRepository.AddWineTastingPackage(package);
            return Ok(package);
        }
       
    }
    
       
