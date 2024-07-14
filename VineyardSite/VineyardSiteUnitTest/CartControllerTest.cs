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

    private static readonly User _testUser = new User()
    {
        Id = "1",
        UserName = "test"
    };

    private static readonly Cart _testCart = new Cart()
    {
        CartId = 1,
        CartItems = new List<CartItem>(),
        UserId = _testUser.Id,
        User = _testUser
        
    }; 
    
    private static readonly Wine _testWine = new Wine
    {
        Id = 0,
        Name = "testName",
        Type = "testType",
        Sweetness = "testSweetness",
        Description = "testDescription"
    };

    private static readonly WineVariant _testVariant = new WineVariant
    {
        Id = 1,
        Wine = _testWine,
        WineId = _testWine.Id,
        AlcoholContent = 15.0,
        Price = 5000.0,
        Year = 2015
    };

    private readonly CartItem _testCartItem = new CartItem()
    {
        Id = 1,
        CartId = _testCart.CartId,
        Cart = _testCart,
        WineVariantId = _testVariant.Id,
        WineVersion = _testVariant,
        Quantity = 1
    };

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

    [Test]
    public async Task AddCartItem_Success_ReturnsOk()
    {
        _userRepositoryMock.Setup(repo => repo.GetByUsername(_testUser.UserName)).ReturnsAsync(_testUser);
        _cartItemRepositoryMock.Setup(repo => repo.AddCartItemAsync(_testCartItem.WineVariantId, _testCartItem.Quantity, _testUser.Id)).Returns(Task.CompletedTask);

        var result = await _cartController.AddCartItem(_testCartItem.WineVariantId, _testCartItem.Quantity, _testUser.UserName);

        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        Assert.That(okResult.Value, Is.EqualTo("Item added to cart"));
    }
}