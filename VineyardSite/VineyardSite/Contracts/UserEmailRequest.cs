namespace VineyardSite.Contracts;

public record UserEmailRequest(string Subject, string Message, string? Name, string? Email, string? Phone, string? Date, int? People);