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
    
    
    
    [HttpPost("/order/AddOrder")]
    public async Task<IActionResult> AddOrder(string username, int wineId,int quantity, DateTime date, string deliveryType, string paymentType,  string? notes)
    {
        var user = await _userRepository.GetByUsername(username);
        if (user == null)
        {
            return NotFound("User not found. Please register/login first");
        }
        var wine = await _wineRepository.GetWineById(wineId);
        if (wine == null)
        {
            return NotFound("Wine not found");
        }
        var order = new Order
        {
            Wine = wine,
            WineId = wine.Id,
            Quantity = quantity,
            TotalPrice = wine.Price * quantity,
            Date = date,
            Address = user.Address,
            DeliveryType = deliveryType,
            PaymentType = paymentType,
            Status = "Pending",
            Notes = notes,
            Email = user.Email,
            User = user,
            UserId = user.Id
            
        };
        await _orderRepository.AddOrder(order);
        return Ok(order);
    }
    
    [HttpDelete("/order/DeleteOrder/{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteOrder(string id)
    {
        try
        {
            await _orderRepository.DeleteOrder(id);
            return Ok("Order deleted");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
       
}
    
    
