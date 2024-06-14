using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
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
}