using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
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
    
}