﻿using Microsoft.AspNetCore.Mvc;
using VineyardSite.Service.Repositories;

namespace VineyardSite.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CartItemController : ControllerBase
{
    private readonly ICartItemRepository _cartItemRepository;
    
    public CartItemController(ICartItemRepository cartItemRepository)
    {
        _cartItemRepository = cartItemRepository;
    }

    [HttpPost("AddCartItem/{drinkId}/{quantity}/{cartId}")]
    public async Task<IActionResult> AddCartItem(int drinkId, int quantity, int cartId)
    {
        try
        {
            await _cartItemRepository.AddCartItemAsync(drinkId, quantity, cartId);
            return Ok("Item added to cart");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Error adding item to cart");
        }
    }
    
}