using System.ComponentModel.DataAnnotations;

namespace VineyardSite.Contracts;

public record RegistrationRequest(
    [Required] string Email,
    [Required] string Username,
    [Required] string Password,
    [Required] string Address);
    