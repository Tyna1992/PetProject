using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using VineyardSite.Contracts;
using VineyardSite.Controllers;
using VineyardSite.Service.Authentication;

namespace VineyardSiteUnitTest;

public class AuthControllerTest
{
    private readonly Mock<IAuthService> _authServiceMock = new();
    private AuthController _authController;
    
    private const string email = "test@test.com";
    private const string username = "testUsername";
    private const string userId = "1";
    private const string password = "password";
    
    [SetUp]
    public void Setup()
    {
        _authController = new AuthController(_authServiceMock.Object)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            }
        };
    }

    [Test]
    public async Task Register_RegistrationSucceeds_ReturnsCreated()
    {
        
        var request = new RegistrationRequest(email, username, password);
        _authServiceMock.Setup(item => item.RegisterAsync(email, username, password, "User"))
            .ReturnsAsync(new AuthResult(true, email, username, ""));

        var result = await _authController.Register(request);
        
        Assert.That(result.Result, Is.InstanceOf<CreatedAtActionResult>());

    }

    [Test]
    public async Task Register_RegistrationFails_ReturnsBadRequest()
    {

        var request = new RegistrationRequest(email, username, password);
        _authServiceMock.Setup(item => item.RegisterAsync(email, username, password, "User"))
            .ReturnsAsync(new AuthResult(false, email, username, ""));

        var result = await _authController.Register(request);
        
        Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
    }
    
    [Test]
    public async Task Register_InvalidModelState_ReturnsBadRequest()
    {
        
        _authController.ModelState.AddModelError("Error", "Invalid model state");
        var request = new RegistrationRequest(email, username, password);
        
        var result = await _authController.Register(request);
        
        Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
    }

    [Test]
    public async Task Login_LoginSucceeds_ReturnsOk()
    {
        var request = new AuthRequest(username, password);
        _authServiceMock.Setup(item => item.LoginAsync(username, password))
            .ReturnsAsync(new AuthResult(true, email, username, "token"));

        var result = await _authController.Authenticate(request);
        
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
    }

    [Test]
    public async Task Login_LoginFails_ReturnsBadRequest()
    {
        var request = new AuthRequest(username, password);
        _authServiceMock.Setup(item => item.LoginAsync(username, password))
            .ReturnsAsync(new AuthResult(false, email, username, ""));

        var result = await _authController.Authenticate(request);
        
        Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
    }
    
    [Test]
    public async Task Login_InvalidModelState_ReturnsBadRequest()
    {
        
        _authController.ModelState.AddModelError("Error", "Invalid model state");
        var request = new AuthRequest(username, password);
        
        var result = await _authController.Authenticate(request);
        
        Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
    }

    [Test]
    public void Logout_ReturnsOk()
    {
        var result = _authController.Logout();
        
        Assert.That(result, Is.InstanceOf<OkResult>());
    }

    [Test]
    public void WhoAmI_TokenIsValid_ReturnsOk()
    {
        var requestCookie = _authController.HttpContext.Request.Cookies["Authorization"];
        var token = new JwtSecurityToken(claims: new List<Claim>
        {
            new("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", email),
            new("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", username),
            new("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", userId)
        });
        _authServiceMock.Setup(item => item.Verify(requestCookie)).Returns(token);

        var result = _authController.WhoAmI();
        
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
    }

    [Test]
    public void WhoAmI_TokenIsInvalid_ReturnsNull()
    {

        var requestCookie = _authController.HttpContext.Request.Cookies["Authorization"];
        _authServiceMock.Setup(x => x.Verify(requestCookie))
            .Returns((JwtSecurityToken)null);

        var result = _authController.WhoAmI();
        
        Assert.That(result.Value, Is.Null);
    }
}