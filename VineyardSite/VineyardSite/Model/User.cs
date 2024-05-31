using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace VineyardSite.Model;

public class User : IdentityUser
{
    [Required]
    public string Address { get; set; }
    [JsonIgnore]
    public Cart Cart { get; set; }
    public int? CartId { get; set; }
    
    
    
}