using System.ComponentModel.DataAnnotations;
using VineyardSite.Model;

namespace HealthManagerServer.Contracts;

public record RegistrationRequest(
    [Required] string Email,
    [Required] string Username,
    [Required] string Password);
    
    