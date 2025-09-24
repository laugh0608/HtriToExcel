using HtriToExcel.Api.Filter;
using Microsoft.AspNetCore.Mvc;

namespace HtriToExcel.Api.Controllers;

[ApiController]
// [Route("api/internal/[controller]/[action]")]
[Route("api/[controller]")]
public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    private readonly ILogger<WeatherForecastController> _logger = logger;

    // [HttpGet(Name = "GetWeatherForecast")]
    [HttpGet]
    // [Tags("Test API")] // 如果不加则默认为 Controller 名称
    // [EndpointGroupName("internal")] // CustomRoute 已经集成了 GroupName
    [CustomRoute(CustomApiVersion.ApiVersions.Internal, "", "Get")]
    // [EndpointSummary("测试 API")]
    // [Badge("V1", BadgePosition.Before, "#007bff")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}