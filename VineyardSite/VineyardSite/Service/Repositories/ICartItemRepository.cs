﻿using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public interface ICartItemRepository
{
    Task AddCartItemAsync(int drinkId, int quantity, string userId);
    Task<CartItem> GetCartItemAsync(int cartItemId);
    Task<IEnumerable<CartItem>> GetCartItemsAsync(string userId);
    Task RemoveCartItemAsync(int cartItemId);
    Task UpdateCartItemAsync(CartItem cartItem);
    
}