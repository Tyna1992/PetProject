using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace VineyardSite.Model;

public class User : IdentityUser
{
    public int AddressId { get; set; }
    [JsonIgnore]
    public Cart Cart { get; set; }
    public int? CartId { get; set; }
    [JsonIgnore]
    public Address Address { get; set; }
    

}