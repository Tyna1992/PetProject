using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VineyardSite.Model;
using VineyardSite.Service.Repositories;

namespace VineyardSite.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly IWineRepository _wineRepository;
    private ILogger<OrderController> _logger;
    
    public OrderController(IOrderRepository orderRepository, IUserRepository userRepository, IWineRepository wineRepository)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
        _wineRepository = wineRepository;
    }
    
    
    
    
       
}
    
    
