using System.Net;
using System.Net.Mail;

namespace VineyardSite.Service.EmailService;

public class EmailSender : IEmailSender
{
    private readonly SmtpClient _client = new("smtp.gmail.com", 587)
    {
        EnableSsl = true,
        UseDefaultCredentials = false,
        Credentials = new NetworkCredential("csobancibormanufakturawebshop@gmail.com", "bhwv pgtz mmjb rzkv")
    };

    public Task SendEmailAsync(string email, string subject, string message)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress("csobancibormanufakturawebshop@gmail.com") ,
            Subject = subject,
            Body = message,
            IsBodyHtml = true
        };
        
        mailMessage.To.Add(email);
        return _client.SendMailAsync(mailMessage);
    }
    
    public async Task SendSignUpEmailAsync(string email, string username)
    {
        // Read the HTML file
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Service/EmailService/EmailTemplates/SignUpEmail.html");
        var htmlMessage = await File.ReadAllTextAsync(path);

        // Replace the placeholder with the user's name
        htmlMessage = htmlMessage.Replace("#user", username);

        // Send the email
        await SendEmailAsync(email, "Successful sign up", htmlMessage);
    }

    public Task SendUserEmailAsync(string email, string userName, string subject, string message)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress(email),
            Subject = subject,
            Body = $"User Name: {userName}\nUser's email: {email}\nUser Message:\n{message}",
            IsBodyHtml = false
        };
        
        mailMessage.To.Add("csobancibormanufakturawebshop@gmail.com");
        mailMessage.ReplyToList.Add(new MailAddress(email));
        return _client.SendMailAsync(mailMessage);
    }
    
    public async Task SendRequestEmailAsync(string email, string subject, string name, string phone, int people, string date, string message)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Service/EmailService/EmailTemplates/WineTastingOfferRequest.html");
        var htmlMessage = await File.ReadAllTextAsync(path);
        
        htmlMessage = htmlMessage.Replace("#user", name);
        htmlMessage = htmlMessage.Replace("#name", name);
        htmlMessage = htmlMessage.Replace("#phone", phone);
        htmlMessage = htmlMessage.Replace("#participants", people.ToString());
        htmlMessage = htmlMessage.Replace("#date", date);
        htmlMessage = htmlMessage.Replace("#details", message);
        
        var mailMessage = new MailMessage
        {
            From = new MailAddress(email),
            Subject = subject,
            Body = htmlMessage,
            IsBodyHtml = true
        };
        
        mailMessage.To.Add("csobancibormanufakturawebshop@gmail.com");
        mailMessage.ReplyToList.Add(new MailAddress(email));
        await _client.SendMailAsync(mailMessage);
    }
    
    public async Task SendRequestEmailAsync(string email, string subject, string name, string message)
    {
        await SendRequestEmailAsync(email, subject, name, string.Empty, 0, string.Empty, message);
    }
}
