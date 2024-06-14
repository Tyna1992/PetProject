using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using VineyardSite.Contracts;
using VineyardSite.Controllers;
using VineyardSite.Model;
using VineyardSite.Service.Repositories;
using VineyardSite.Service.Repositories.Profile;

namespace VineyardSiteUnitTest;

public class UserControllerTest
{
    private Mock<IUserRepository> _userRepositoryMock;
    private Mock<IAddressRepository> _addressRepositoryMock;
    private UserController _userController;
    
    private User testUser = new User
    {
        Id = "1",
        UserName = "testUser",
        Email = "test@test.com",
        PhoneNumber = "123456789",
        AddressId = 1,
        Cart = new Cart { CartId = 1 },
        Address = new Address { AddressId = 1, Street = "Test", HouseNumber = "12", City = "Testville", ZipCode = "12345", Country = "testCountry", UserId = "1"}
    };
    
    [SetUp]
    public void Setup()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _addressRepositoryMock = new Mock<IAddressRepository>();
        _userController = new UserController(_userRepositoryMock.Object, _addressRepositoryMock.Object)
        {
            ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            }
        };
    }

    [Test]
    public async Task GetUserDetails_UserExists_ReturnsOk()
    {
        
        _userRepositoryMock.Setup(repo => repo.GetUserById(testUser.Id)).ReturnsAsync(testUser);

        var result = await _userController.GetUserDetails(testUser.Id);

        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var okResult = ((OkObjectResult)result).Value;
        Assert.That(okResult, Is.Not.Null);

        var expected = new { UserName = "testUser", Email = "test@test.com", PhoneNumber = "123456789" };
        
        Assert.That(okResult.ToString(), Is.EqualTo(expected.ToString()));
    }

    [Test]
    public async Task GetUserDetails_UserNotExists_ReturnsNotFound()
    {
        _userRepositoryMock.Setup(repo => repo.GetUserById(testUser.Id)).ReturnsAsync((User)null);

        var result = await _userController.GetUserDetails(testUser.Id);
        
        Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
        var notFoundResult = result as NotFoundObjectResult;
        Assert.That(notFoundResult.Value, Is.EqualTo("User not found"));
    }
}