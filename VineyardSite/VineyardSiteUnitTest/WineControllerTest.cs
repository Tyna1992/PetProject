using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using VineyardSite.Contracts;
using VineyardSite.Controllers;
using VineyardSite.Service.Repositories;

namespace VineyardSiteUnitTest;

public class WineControllerTest
{
    private readonly Mock<IWineRepository> _wineRepositoryMock;
    private WineController _wineController;

    [SetUp]
    public void Setup()
    {
        _wineController = new WineController(_wineRepositoryMock.Object)
        {
            ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            }
        };
    }
}