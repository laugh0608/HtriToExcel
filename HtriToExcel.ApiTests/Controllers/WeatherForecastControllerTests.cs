using HtriToExcel.Api.Controllers;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace HtriToExcel.ApiTests.Controllers;

[TestClass]
[TestSubject(typeof(WeatherForecastController))]
public class WeatherForecastControllerTest
{
    [TestMethod()]
    public void GetTest()
    {
        ILogger<WeatherForecastController> logger = new NullLogger<WeatherForecastController>();
        var controller = new WeatherForecastController(logger);
        Assert.IsNotNull(controller);
    }
}