using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using VineyardSite.Contracts;
using VineyardSite.Controllers;
using VineyardSite.Model;
using VineyardSite.Service.Repositories;

namespace VineyardSiteUnitTest;

public class VariantControllerTest
{
    private Mock<IWineVariantRepository> _wineVariantRepositoryMock;
    private Mock<IWineRepository> _wineRepositoryMock;
    private VariantController _variantController;
    private ILogger<VariantController> _logger;

    private static readonly Wine _testWine = new Wine
    {
        Id = 0,
        Name = "testName",
        Type = "testType",
        Sweetness = "testSweetness",
        Description = "testDescription"
    };

    private readonly WineVariant _testVariant = new WineVariant
    {
        Wine = _testWine,
        WineId = _testWine.Id,
        AlcoholContent = 15.0,
        Price = 5000.0,
        Year = 2015
    };

    [SetUp]
    public void Setup()
    {
        _wineVariantRepositoryMock = new Mock<IWineVariantRepository>();
        _wineRepositoryMock = new Mock<IWineRepository>();
        _variantController =
            new VariantController(_wineVariantRepositoryMock.Object, _logger, _wineRepositoryMock.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
    }

    [Test]
    public async Task AddVariant_SuccessAdded_ReturnsOk()
    {
        _wineRepositoryMock.Setup(repo => repo.GetWineByName("testName")).ReturnsAsync(_testWine);
        _wineVariantRepositoryMock.Setup(repo => repo.AddWineVariant(It.IsAny<WineVariant>()))
            .Returns(Task.CompletedTask);
        var result = await _variantController.AddVariant("testName", 5000.0, 15.0, 2015);

        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        var actualVariant = okResult.Value as WineVariant;
        
        Assert.That(actualVariant, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(actualVariant.WineId, Is.EqualTo(_testWine.Id));
            Assert.That(actualVariant.Wine, Is.EqualTo(_testWine));
            Assert.That(actualVariant.Price, Is.EqualTo(_testVariant.Price));
            Assert.That(actualVariant.AlcoholContent, Is.EqualTo(_testVariant.AlcoholContent));
            Assert.That(actualVariant.Year, Is.EqualTo(_testVariant.Year));
        });
    }

    [Test]
    public async Task AddVariant_WineNotFound_ReturnsNotFound()
    {
        _wineRepositoryMock.Setup(repo => repo.GetWineByName("NotExistingWine")).ReturnsAsync((Wine)null);
        
        var result = await _variantController.AddVariant("NotExistingWine", 5000.0, 15.0, 2015);
        
        Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
        var notFoundResult = result as NotFoundObjectResult;
        Assert.That(notFoundResult.Value, Is.EqualTo("No wine found with that name in catalog"));
    }

    [Test]
    public async Task AddVariant_InvalidYear_ReturnsStatusCode406()
    {
        _wineRepositoryMock.Setup(repo => repo.GetWineByName("testName")).ReturnsAsync(_testWine);

        var result1 = await _variantController.AddVariant("testName", 5000.0, 15.0, -1);
        var result2 = await _variantController.AddVariant("testName", 5000.0, 15.0, 3000);
        
        Assert.That(result1, Is.InstanceOf<ObjectResult>());
        Assert.That(result2, Is.InstanceOf<ObjectResult>());

        var objectResult1 = result1 as ObjectResult;
        var objectResult2 = result2 as ObjectResult;
        
        Assert.That(objectResult1.StatusCode, Is.EqualTo(406));
        Assert.That(objectResult1.Value, Is.EqualTo("Invalid year"));
        Assert.That(objectResult2.StatusCode, Is.EqualTo(406));
        Assert.That(objectResult2.Value, Is.EqualTo("Invalid year"));

    }
}