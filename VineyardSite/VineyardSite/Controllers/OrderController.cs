using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
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

    [HttpPost("AddOrder/{userId}"), Authorize(Roles = "User,Admin")]
    public async Task<IActionResult> PlaceOrder(string userId, [FromBody] OrderRequest orderRequest)
    {
        try
        {
           var order = await _orderRepository.AddOrder(userId, orderRequest);
           var response = new OrderResponse
           {
               Id = order.Id,
               Date = order.Date,
               Username = order.User.UserName,
               TotalPrice = order.TotalPrice,
               Address = order.Address,
               DeliveryType = order.DeliveryType,
               PaymentType = order.PaymentType,
               Status = order.Status,
               Items = order.OrderItems.Select(oi => oi.WineVariant).ToList()
           };
            return Ok(response);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest();
        }
        
    }
    
    
       
}
    
    
