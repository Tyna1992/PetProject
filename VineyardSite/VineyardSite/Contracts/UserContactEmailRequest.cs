namespace VineyardSite.Contracts;

public record UserContactEmailRequest(string Email, string Name, string Subject, string Message);