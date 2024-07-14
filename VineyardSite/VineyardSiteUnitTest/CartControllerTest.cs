using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using VineyardSite.Controllers;
using VineyardSite.Model;
using VineyardSite.Model.Address;
using VineyardSite.Service.Repositories;
namespace VineyardSiteUnitTest;

public class CartControllerTest
{
    private Mock<ICartItemRepository> _cartItemRepositoryMock;
    private Mock<ICartRepository> _cartRepositoryMock;
    private Mock<IUserRepository> _userRepositoryMock;
    private CartController _cartController;

    [SetUp]
    public void Setup()
    {
        _cartRepositoryMock = new Mock<ICartRepository>();
        _cartItemRepositoryMock = new Mock<ICartItemRepository>();
        _userRepositoryMock = new Mock<IUserRepository>();
        _cartController = new CartController(_cartItemRepositoryMock.Object, _cartRepositoryMock.Object, _userRepositoryMock.Object)
        {
            ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            }
        };
    }
}