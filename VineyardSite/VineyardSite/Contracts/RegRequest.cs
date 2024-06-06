using System.ComponentModel.DataAnnotations;
using VineyardSite.Model;

namespace VineyardSite.Contracts;

public record RegistrationRequest(
    [Required] string Email,
    [Required] string Username,
    [Required] string Password);
    
    