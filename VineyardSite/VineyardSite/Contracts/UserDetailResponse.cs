using VineyardSite.Model;

namespace VineyardSite.Contracts;

public record UserDetailResponse(
    string Email,
    Address Address,
    string PhoneNumber);