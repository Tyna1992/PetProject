using System.Text.Json.Serialization;

namespace VineyardSite.Model;

public class CartItem
{
    public int Id { get; set; }
    public int CartId { get; set; }
    [JsonIgnore]
    public Cart Cart { get; set; }
    public int WineVariantId { get; set; }
    public WineVariant WineVersion { get; set; }
    public int Quantity { get; set; }
}