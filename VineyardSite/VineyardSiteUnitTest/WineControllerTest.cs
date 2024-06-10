using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using VineyardSite.Contracts;
using VineyardSite.Controllers;
using VineyardSite.Model;
using VineyardSite.Service.Repositories;

namespace VineyardSiteUnitTest;

public class WineControllerTest
{
    private Mock<IWineRepository> _wineRepositoryMock;
    private WineController _wineController;

    [SetUp]
    public void Setup()
    {
        _wineRepositoryMock = new Mock<IWineRepository>();
        _wineController = new WineController(_wineRepositoryMock.Object)
        {
            ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            }
        };
    }

    [Test]
    public async Task AddWine_Success_ReturnsOk()
    {
        Wine testWine = new Wine
        {
            Id = 1,
            Name = "testName",
            Type = "testType",
            Sweetness = "testSweetness",
            Description = "testDescrition"
        };

        _wineRepositoryMock.Setup(repo => repo.AddWine(It.IsAny<Wine>())).Returns(Task.CompletedTask);

        var result = await _wineController.AddWine(testWine);
        
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        Assert.That(okResult.Value, Is.EqualTo(testWine));
    }
}