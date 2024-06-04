namespace VineyardSite.Model;

public class OrderRequest
{
    public string UserId { get; set; }
    public string DeliveryType { get; set; }
    public string PaymentType { get; set; }
    public string? Notes { get; set; }
}