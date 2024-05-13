namespace VineyardSite.Model;

public class WineVariant
{
    public int Id { get; set; }
    public Wine Wine { get; set; }
    public int WineId { get; set; }
    public double AlcoholContent { get; set; }
    public double Price { get; set; }
    public int Year { get; set; }
}