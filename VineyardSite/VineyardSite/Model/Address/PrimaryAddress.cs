﻿using System.Text.Json.Serialization;

namespace VineyardSite.Model.Address;

public class PrimaryAddress
{
    public int PrimaryAddressId { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    [JsonIgnore]
    public User? User { get; set; }
    public string UserId { get; set; }

}