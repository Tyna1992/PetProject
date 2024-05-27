namespace VineyardSite.Model;

public class CartItem
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public Cart Cart { get; set; }
    public int WineVariantId { get; set; }
    public WineVariant WineVersion { get; set; }
    public int Quantity { get; set; }
}