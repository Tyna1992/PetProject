using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VineyardSite.Contracts;
using VineyardSite.Service.Authentication;
using VineyardSite.Service.EmailService;


namespace VineyardSite.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authenticationService;
    private readonly IEmailSender _emailSender;
    
    public AuthController(IAuthService authenticationService, IEmailSender emailSender)
    {
        _authenticationService = authenticationService;
        _emailSender = emailSender;
    }
    
    
    [HttpPost("Register")]
    public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _authenticationService.RegisterAsync(request.Email, request.Username, request.Password, "User");

        if (!result.Success)
        {
            AddErrors(result);
            return BadRequest(ModelState);
        }

        await _emailSender.SendSignUpEmailAsync(result.Email, result.UserName);
        return CreatedAtAction(nameof(Register), new RegistrationResponse(result.Email, result.UserName));
    }
    
    [HttpPost("Login")]
    public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _authenticationService.LoginAsync(request.UserName, request.Password);

        if (!result.Success)
        {
            AddErrors(result);
            return BadRequest(ModelState);
        }

        Response.Cookies.Append("Authorization", result.Token, new CookieOptions
        {
            HttpOnly = true
        });

        return Ok(new AuthResponse(result.Email, result.UserName));
    }
    [HttpGet("WhoAmI"), Authorize(Roles = "User,Admin")]
    public ActionResult<UserResponse> WhoAmI()
    {
        var cookieString = Request.Cookies["Authorization"];

        var token = _authenticationService.Verify(cookieString);

        if (token != null)
        {
            var claims = token.Claims;
            var email = claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            var username = claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;
            var userId = claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            
            return Ok(new UserResponse(userId, username, email ));
        }
        return BadRequest("No token found");
    }

    [HttpPost("Logout"), Authorize(Roles = "User,Admin")]
    public ActionResult Logout()
    {
        Response.Cookies.Delete("Authorization");
        return Ok();
    }
    
    private void AddErrors(AuthResult result)
    {
        foreach (var error in result.ErrorMessages)
        {
            ModelState.AddModelError(error.Key, error.Value);
        }
    }
}