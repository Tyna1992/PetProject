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

}