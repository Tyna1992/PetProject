namespace VineyardSite.Model;

public class OrderResponse
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public double TotalPrice { get; set; }
    public DateTime Date { get; set; }
    public string Address { get; set; }
    public string DeliveryType { get; set; }
    public string PaymentType { get; set; }
    public string Status { get; set; }
    public ICollection<WineVariant> Items { get; set; }
}