using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using VineyardSite.Contracts;
using VineyardSite.Service.EmailService;

namespace VineyardSite.Controllers;

[ApiController]
[Route("api/[controller]")]

public class EmailSenderController : ControllerBase
{
    private readonly IEmailSender _emailSender;
    
    public EmailSenderController(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    [HttpPost("sendEmail")]
    public async Task<IActionResult> SendUserEmail([FromBody] UserEmailRequest request)
    {
        try
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            Console.WriteLine(userEmail);
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;
            Console.WriteLine(userName);
            
            if (userEmail != null && userName != null)
            {
                await _emailSender.SendUserEmailAsync(userEmail, request.Subject, userName, request.Message);
            }
            else
            {
                return BadRequest("User email or name not found.");
            }

            return Ok("Email sent successfully.");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost("sendRequestEmail")]
    public async Task<IActionResult> SendRequestEmail([FromBody] UserEmailRequest request)
    {
        try
        {
            await _emailSender.SendRequestEmailAsync(request.Email, request.Subject, request.Name, request.Phone, (int)request.People, request.Date, request.Message);

            return Ok("Email sent successfully.");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}