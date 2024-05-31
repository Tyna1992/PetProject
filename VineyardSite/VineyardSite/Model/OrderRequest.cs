namespace VineyardSite.Model;

public class OrderRequest
{
    public string DeliveryType { get; set; }
    public string PaymentType { get; set; }
    public string? Notes { get; set; }
}