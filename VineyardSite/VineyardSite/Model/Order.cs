namespace VineyardSite.Model;

public class Order
{
    public Guid Id { get; set; }
    public WineVariant WineVariant { get; set; }
    public int WineVariantId { get; set; }
    public int Quantity { get; set; }
    public double TotalPrice { get; set; }
    public DateTime Date { get; set; }
    public string Address { get; set; }
    public string DeliveryType { get; set; }
    public string PaymentType { get; set; }
    public string Status { get; set; }
    public string Notes { get; set; }
    public string Email { get; set; }
    public User User { get; set; }
    public string UserId { get; set; }
    
}