namespace VineyardSite.Service.EmailService;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string subject, string message);
    Task SendSignUpEmailAsync(string email, string username);
}

    