using System.Net;
using System.Net.Mail;

namespace VineyardSite.Service.EmailService;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string message)
    {
        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("csobancibormanufakturawebshop@gmail.com", "bhwv pgtz mmjb rzkv")

        };
        var mailMessage = new MailMessage
        {
            From = new MailAddress("csobancibormanufakturawebshop@gmail.com") ,
            Subject = subject,
            Body = message,
            IsBodyHtml = true
        };
        
        mailMessage.To.Add(email);
        return client.SendMailAsync(mailMessage);
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
}
