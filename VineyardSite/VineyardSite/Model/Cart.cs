namespace VineyardSite.Model;

public class Cart
{
    public int CartId { get; set; }
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    public string UserId { get; set; }
    public User User { get; set; }
}