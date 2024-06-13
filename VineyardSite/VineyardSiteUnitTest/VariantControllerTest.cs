using Microsoft.AspNetCore.Http;
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

    private Wine _testWine = new Wine
    {
        Id = 1,
        Name = "testName",
        Type = "testType",
        Sweetness = "testSweetness",
        Description = "testDescription"
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
    
}

