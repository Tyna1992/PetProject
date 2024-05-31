using System.Text.Json.Serialization;

namespace VineyardSite.Model;

public class OrderItem
{
    public Guid Id { get; set; }
    public WineVariant WineVariant { get; set; }
    public int WineVariantId { get; set; }
    public int Quantity { get; set; }
    [JsonIgnore]
    public Order Order { get; set; }
    public Guid OrderId { get; set; }
    
}