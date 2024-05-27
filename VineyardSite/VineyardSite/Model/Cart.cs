namespace VineyardSite.Model;

public class Cart
{
    public int CartId { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
    public string UserId { get; set; }
}