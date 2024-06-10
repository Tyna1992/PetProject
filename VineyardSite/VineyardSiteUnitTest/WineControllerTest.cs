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
        Id = 0,
        Name = "testName",
        Type = "testType",
        Sweetness = "testSweetness",
        Description = "testDescrition"
    };
    
    private List<Wine> _testWines = new List<Wine>
    {
        new Wine { Id = 1, Name = "testWine1", Type = "testType1", Sweetness = "testSweetness1", Description = "testDescription1" },
        new Wine { Id = 2, Name = "testWine2", Type = "testType2", Sweetness = "testSweetness2", Description = "testDescription2" }
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
    
    [Test]
    public async Task GetAllWine_Success_ReturnsOkWithWineList()
    {

        _wineRepositoryMock.Setup(repo => repo.GetAllWine()).ReturnsAsync(_testWines);
        
        var result = await _wineController.GetAllWine();
        
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        Assert.That(okResult.Value, Is.EqualTo(_testWines));
    }
    
    [Test]
    public async Task GetAllWine_Fails_ReturnsBadRequest()
    {
        _wineRepositoryMock.Setup(repo => repo.GetAllWine()).ThrowsAsync(new Exception("Test Exception"));
        
        var result = await _wineController.GetAllWine();
        
        Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        var badRequestResult = result as BadRequestObjectResult;
        Assert.That(badRequestResult.Value, Is.EqualTo("Test Exception"));
    }

    [Test]
    public async Task DeleteWine_DeleteSuccess_ReturnsOk()
    {
        _wineRepositoryMock.Setup(repo => repo.DeleteWine(_testWines[0].Id)).Returns(Task.CompletedTask);

        var result = await _wineController.DeleteWine(_testWines[0].Id);
        
        Assert.That(result, Is.InstanceOf<OkResult>());
    }

    [Test]
    public async Task DeleteWine_DeleteFails_ReturnsBadRequest()
    {
        _wineRepositoryMock.Setup(repo => repo.DeleteWine(_testWines[0].Id))
            .ThrowsAsync(new Exception("Test Exception"));

        var result = await _wineController.DeleteWine(_testWines[0].Id);
        
        Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        var badRequestResult = result as BadRequestObjectResult;
        Assert.That(badRequestResult.Value, Is.EqualTo("Test Exception"));
    }

    [Test]
    public async Task UpdateWine_UpdateSuccess_ReturnsOk()
    {

        _wineRepositoryMock.Setup(repo => repo.UpdateWine(_testWines[0].Id, _testWine)).Returns(Task.CompletedTask);

        var result = await _wineController.UpdateWine(_testWines[0].Id, _testWine);
        
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        Assert.That(okResult.Value, Is.EqualTo(_testWine));
    }
    
}