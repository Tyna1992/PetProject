namespace VineyardSite.Contracts;

public record UserDetailResponse(
    string Email,
    string Address,
    string PhoneNumber);