using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using VineyardSite.Controllers;
using VineyardSite.Model;
using VineyardSite.Model.Address;
using VineyardSite.Service.Repositories;

namespace VineyardSiteUnitTest;

public class OrderControllerTest
{
        private Mock<IOrderRepository> _orderRepositoryMock;
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IWineRepository> _wineRepositoryMock;
        private Mock<ILogger<OrderController>> _loggerMock;
        private OrderController _orderController;
        
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

        private readonly OrderItem _testOrderItem = new OrderItem()
        {
                WineVariant = _testVariant,
                WineVariantId = _testVariant.Id,
                Quantity = 1,
        };
        
        private OrderRequest _testOrderRequest = new ()
        {
                UserId = "1",
                DeliveryType = "test",
                PaymentType = "test",
                Notes = "test"
                
        }; 
        [SetUp]
        public void Setup()
        {
                _orderRepositoryMock = new Mock<IOrderRepository>();
                _userRepositoryMock = new Mock<IUserRepository>();
                _wineRepositoryMock = new Mock<IWineRepository>();
                _loggerMock = new Mock<ILogger<OrderController>>();
                _orderController = new OrderController(_orderRepositoryMock.Object, _userRepositoryMock.Object,
                        _wineRepositoryMock.Object)
                {
                        ControllerContext = new ControllerContext()
                        {
                                HttpContext = new DefaultHttpContext()
                        }
                };

        }

        [Test]
        public async Task PlaceOrder_OrderSuccess_ReturnsOk()
        {
            var testOrder = new Order()
            {
                OrderItems = new List<OrderItem>()
                {
                    _testOrderItem
                },
                TotalPrice = 1000.00,
                Date = DateTime.Today,
                Address = "test address",
                DeliveryType = _testOrderRequest.DeliveryType,
                PaymentType = _testOrderRequest.PaymentType,
                Status = "test",
                Notes = _testOrderRequest.Notes,
                Email = "test@test.com",
                User = new User()
                {
                    UserName = "test",
                },
                UserId = "1"
            };

            _orderRepositoryMock.Setup(repo => repo.AddOrder(_testOrderRequest.UserId, _testOrderRequest)).ReturnsAsync(testOrder);

            var expectedResult = new OrderResponse()
            {
                Id = testOrder.Id,
                Date = testOrder.Date,
                Username = testOrder.User.UserName,
                TotalPrice = testOrder.TotalPrice,
                Address = testOrder.Address,
                DeliveryType = testOrder.DeliveryType,
                PaymentType = testOrder.PaymentType,
                Status = testOrder.Status,
                Items = testOrder.OrderItems.Select(oi => oi.WineVariant).ToList()
            };

            var result = await _orderController.PlaceOrder(_testOrderRequest);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            var actualResult = okResult.Value as OrderResponse;

            Assert.NotNull(actualResult);
            Assert.That(actualResult.Id, Is.EqualTo(expectedResult.Id));
            Assert.That(actualResult.Date, Is.EqualTo(expectedResult.Date));
            Assert.That(actualResult.Username, Is.EqualTo(expectedResult.Username));
            Assert.That(actualResult.TotalPrice, Is.EqualTo(expectedResult.TotalPrice));
            Assert.That(actualResult.Address, Is.EqualTo(expectedResult.Address));
            Assert.That(actualResult.DeliveryType, Is.EqualTo(expectedResult.DeliveryType));
            Assert.That(actualResult.PaymentType, Is.EqualTo(expectedResult.PaymentType));
            Assert.That(actualResult.Status, Is.EqualTo(expectedResult.Status));
            CollectionAssert.AreEqual(expectedResult.Items.Select(i => i.Id), actualResult.Items.Select(i => i.Id));
        }

        [Test]
        public async Task PlaceOrder_OrderFails_ReturnsBadRequest()
        {
                _orderRepositoryMock.Setup(repo => repo.AddOrder(_testOrderRequest.UserId, _testOrderRequest))
                        .ThrowsAsync(new Exception("Order creation failed"));
                
                var result = await _orderController.PlaceOrder(_testOrderRequest);
                
                Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }
}