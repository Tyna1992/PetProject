using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using VineyardSite.Model.Address;

namespace VineyardSite.Model;

public class User : IdentityUser
{
    public int PrimaryAddressId { get; set; }
    public int AddressId { get; set; }
    
    [JsonIgnore]
    public Cart Cart { get; set; }
    public int? CartId { get; set; }
    [JsonIgnore]
    public PrimaryAddress PrimaryAddress { get; set; }
    public ICollection<Address.Address> Addresses { get; set; }
    

}