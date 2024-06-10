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
    private Wine _testWine = new Wine
    {
        Id = 1,
        Name = "testName",
        Type = "testType",
        Sweetness = "testSweetness",
        Description = "testDescrition"
    };
    
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
    public async Task AddWine_SuccessAdded_ReturnsOk()
    {

        _wineRepositoryMock.Setup(repo => repo.AddWine(It.IsAny<Wine>())).Returns(Task.CompletedTask);

        var result = await _wineController.AddWine(_testWine);
        
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        Assert.That(okResult.Value, Is.EqualTo(_testWine));
    }

    [Test]

    public async Task AddWine_FailsAdded_ReturnsBadRequest()
    {
        _wineRepositoryMock.Setup(repo => repo.AddWine(It.IsAny<Wine>())).ThrowsAsync(new Exception("Test Exception"));

        var result = await _wineController.AddWine(_testWine);
        
        Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        var badRequestResult = result as BadRequestObjectResult;
        Assert.That(badRequestResult.Value, Is.EqualTo("Test Exception"));
    }
    
}