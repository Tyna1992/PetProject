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

    [HttpPost("sendContactEmail")]
    public async Task<IActionResult> SendUserEmail([FromBody] UserContactEmailRequest request)
    {
        try
        {
            await _emailSender.SendUserEmailAsync(request.Email, request.Name, request.Subject, request.Message);
            
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