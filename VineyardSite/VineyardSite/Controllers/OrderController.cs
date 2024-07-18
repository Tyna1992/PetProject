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
    
    public OrderController(IOrderRepository orderRepository, IUserRepository userRepository, IWineRepository wineRepository)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
        _wineRepository = wineRepository;
    }

    [HttpPost("AddOrder"), Authorize(Roles = "User,Admin")]
    public async Task<IActionResult> PlaceOrder([FromBody] OrderRequest orderRequest)
    {
        try
        {
            var userId = orderRequest.UserId;
            var order = await _orderRepository.AddOrder(userId, orderRequest);
           Console.WriteLine("Order: " + order.Id, order.Date, order.TotalPrice, order.Status);
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
            return BadRequest();
        }
        
    }

    [HttpGet("GetOrdersByUserId/{userId}")]
    public async Task<IActionResult> GetOrdersByUserId(string userId)
    {
        try
        {
            var orders = await _orderRepository.GetOrdersByUserId(userId);
            return Ok(orders);
        }
        catch(Exception e)
        {
            return BadRequest();
        }
    }

    [HttpGet("GetOrders")]
    public async Task<IActionResult> GetAllOrders()
    {
        try
        {
            var orders = await _orderRepository.GetAllOrders();
            return Ok(orders);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpPatch("UpdateOrder/{id}/{status}")]
    public async Task<IActionResult> UpdateOrder(string id, string status)
    {
        try
        {
            await _orderRepository.UpdateOrder(id, status);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
       
}
    
    
