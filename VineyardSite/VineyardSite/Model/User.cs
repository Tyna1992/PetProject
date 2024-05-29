using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace VineyardSite.Model;

public class User : IdentityUser
{
    [Required]
    public string Address { get; set; }
    public Cart Cart { get; set; }
    public int? CartId { get; set; }
    
    
    
}