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
        Address = new Address
        {
            AddressId = 1, Street = "Test", HouseNumber = "12", City = "Testville", ZipCode = "12345",
            Country = "testCountry", UserId = "1"
        }
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

    [Test]
    public async Task UpdateUser_SuccessUpdate_ReturnsOk()
    {
        var userDetailResponse = new UserDetailResponse("test1@test.com", "987654321");
        var updatedUser = new User
        {
            Id = testUser.Id, UserName = "testUser", Email = userDetailResponse.Email,
            PhoneNumber = userDetailResponse.PhoneNumber
        };
        _userRepositoryMock.Setup(repo => repo.UpdateUser(testUser.Id, userDetailResponse)).ReturnsAsync(updatedUser);

        var result = await _userController.UpdateUser(testUser.Id, userDetailResponse);

        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        Assert.That(okResult.Value, Is.EqualTo("User updated"));
    }

    [Test]
    public async Task UpdateUser_ThrowsException_ReturnsStatusCode500()
    {
        var userDetailResponse = new UserDetailResponse("test1@test.com", "987654321");
        _userRepositoryMock.Setup(repo => repo.UpdateUser(testUser.Id, userDetailResponse))
            .ThrowsAsync(new Exception());

        var result = await _userController.UpdateUser(testUser.Id, userDetailResponse);

        Assert.That(result, Is.InstanceOf<ObjectResult>());
        var objectResult = result as ObjectResult;
        Assert.Multiple(() =>
        {
            Assert.That(objectResult.StatusCode, Is.EqualTo(500));
            Assert.That(objectResult.Value, Is.EqualTo("Error updating user"));
        });
    }

    [Test]
    public async Task ChangePassword_SuccessChange_ReturnsOk()
    {
        var passwordChangeResponse = new PasswordChangeResponse("pass1", "newPass");
        var updatedUser = new User
        {
            Id = testUser.Id,
            UserName = "testUser",
            Email = "test@test.com",
            PhoneNumber = "1234566789"
        };
        _userRepositoryMock.Setup(repo => repo.ChangePassword(testUser.Id, passwordChangeResponse))
            .ReturnsAsync(updatedUser);

        var result = await _userController.ChangePassword(testUser.Id, passwordChangeResponse);

        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        Assert.That(okResult.Value, Is.EqualTo("Password changed"));
    }

    [Test]
    public async Task ChangePassword_FailsChange_ReturnsBadRequest()
    {
        var passwordChangeResponse = new PasswordChangeResponse("pass1", "newPass");
        _userRepositoryMock.Setup(repo => repo.ChangePassword(testUser.Id, passwordChangeResponse))
            .ThrowsAsync(new Exception());

        var result = await _userController.ChangePassword(testUser.Id, passwordChangeResponse);

        Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        var badRequestObjectResult = result as BadRequestObjectResult;
        Assert.That(badRequestObjectResult.Value, Is.EqualTo("Error changing password"));
    }

    [Test]
    public async Task AddAddress_SuccessAdd_ReturnsOk()
    {
        var testAddress = new Address()
        {
            AddressId = 1, Street = "Test", HouseNumber = "12", City = "Testville", ZipCode = "12345",
            Country = "testCountry", UserId = "1"
        };

        _addressRepositoryMock.Setup(repo => repo.AddAddressToUser(testUser.Id, testAddress))
            .Returns(Task.CompletedTask);

        var result = await _userController.AddAddress(testUser.Id, testAddress);
        
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        Assert.That(okResult.Value, Is.EqualTo("Address added"));
    }

    [Test]
    public async Task AddAddress_FailsAdded_ReturnsStatusCode500()
    {
        var testAddress = new Address()
        {
            AddressId = 1, Street = "Test", HouseNumber = "12", City = "Testville", ZipCode = "12345",
            Country = "testCountry", UserId = "1"
        };
        _addressRepositoryMock.Setup(repo => repo.AddAddressToUser(testUser.Id, testAddress))
            .ThrowsAsync(new Exception());

        var result = await _userController.AddAddress(testUser.Id, testAddress);
        
        Assert.That(result, Is.InstanceOf<ObjectResult>());
        var objectResult = result as ObjectResult;
        Assert.That(objectResult.Value, Is.EqualTo("Error adding address"));
        Assert.That(objectResult.StatusCode, Is.EqualTo(500));
    }

    [Test]
    public async Task GetAddress_Success_ReturnsOk()
    {
        _addressRepositoryMock.Setup(repo => repo.GetAddress(testUser.Id)).ReturnsAsync(testUser.Address);

        var result = await _userController.GetAddress(testUser.Id);
        
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        Assert.That(okResult.Value, Is.EqualTo(testUser.Address));
    }
}