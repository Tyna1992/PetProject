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

    
    }
    
       
