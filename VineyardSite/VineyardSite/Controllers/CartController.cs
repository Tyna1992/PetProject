using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VineyardSite.Service.Repositories;

namespace VineyardSite.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly ICartRepository _cartRepository;

    private readonly IUserRepository _userRepository;
    
    
    public CartController(ICartItemRepository cartItemRepository, ICartRepository cartRepository, IUserRepository userRepository)
    {
        _cartItemRepository = cartItemRepository;
        _cartRepository = cartRepository;
        _userRepository = userRepository;
    }
   

    [HttpPost("AddCartItem/{drinkId}/{quantity}/{userName}"), Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> AddCartItem(int drinkId, int quantity, string userName)
    {
        try
        {
            var user = await _userRepository.GetByUsername(userName);
            await _cartItemRepository.AddCartItemAsync(drinkId, quantity, user.Id);
            return Ok("Item added to cart");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Error adding item to cart");
        }
    }
    
    [HttpDelete("RemoveCartItem/{cartItemId}"), Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> RemoveCartItem(int cartItemId)
    {
        try
        {
            await _cartItemRepository.RemoveCartItemAsync(cartItemId);
            return Ok("Item removed from cart");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Error removing item from cart");
        }
    }
    
    [HttpPatch("UpdateQuantity/{cartItemId}"), Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> UpdateQuantity(int cartItemId, int quantity)
    {
        try
        {
            var cartItem = await _cartItemRepository.GetCartItemAsync(cartItemId);
            
            cartItem.Quantity = quantity;
            await _cartItemRepository.UpdateCartItemAsync(cartItem);
            return Ok("Item quantity updated");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Error updating item quantity");
        }
    }

    [HttpGet("GetCart/{userName}"), Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> GetCart(string userName)
    {
        try
        {
            var user = await _userRepository.GetByUsername(userName);
            Console.WriteLine(user.Id);        
            
            var cartItems = await _cartItemRepository.GetCartItemsAsync(user.Id);
            return !cartItems.Any() ? Ok("Cart is empty") : Ok(cartItems);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Error getting cart items");
        }
    }
}