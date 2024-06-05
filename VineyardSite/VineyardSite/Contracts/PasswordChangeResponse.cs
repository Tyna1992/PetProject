namespace VineyardSite.Contracts;

public record PasswordChangeResponse(
    string OldPassword,
    string NewPassword
    );