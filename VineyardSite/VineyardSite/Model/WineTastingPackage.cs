namespace VineyardSite.Model;

public class WineTastingPackage
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public Wine Wine1 { get; set; }
    public Wine? Wine2 { get; set; }
    public Wine? Wine3 { get; set; }
    public Wine? Wine4 { get; set; }
    public int Wine1Id { get; set; }
    public int? Wine2Id { get; set; }
    public int? Wine3Id { get; set; }
    public int? Wine4Id { get; set; }
    public Snack? Snack { get; set; }
    public int? SnackId { get; set; }
}