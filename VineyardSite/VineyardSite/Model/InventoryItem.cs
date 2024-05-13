namespace VineyardSite.Model;

public class InventoryItem
{
    public int Id { get; set; }
    public int WineVariantId { get; set; }
    public WineVariant WineVersion { get; set; }
    public int Quantity { get; set; }
}