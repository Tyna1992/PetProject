namespace VineyardSite.Service.EmailService;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string subject, string message);
    Task SendSignUpEmailAsync(string email, string username);
    Task SendUserEmailAsync(string email, string subject, string userName, string message);
    Task SendRequestEmailAsync(string email, string subject, string name, string phone, int people, string date, string message);
}

    