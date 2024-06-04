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
        const string email = "test@test.com";
        const string username = "testUsername";
        const string password = "password";
        const string address = "testAddress";

        var request = new RegistrationRequest(email, username, password, address);
        _authServiceMock.Setup(item => item.RegisterAsync(email, username, password, address, "User"))
            .ReturnsAsync(new AuthResult(true, email, username, ""));

        var result = await _authController.Register(request);
        
        Assert.That(result.Result, Is.InstanceOf<CreatedAtActionResult>());

    }
    
}