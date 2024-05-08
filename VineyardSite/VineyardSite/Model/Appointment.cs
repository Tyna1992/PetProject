namespace VineyardSite.Model;

public class Appointment
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int People { get; set; }
    public string Name { get; set; }
    public string? Requests { get; set; }
    public string Email { get; set; }
    public User User { get; set; }
    public string UserId { get; set; }
    public WineTastingPackage Package { get; set; }
    public int PackageId { get; set; }
}