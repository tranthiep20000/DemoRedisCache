using DemoRedisCache.Attributes;
using DemoRedisCache.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoRedisCache.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IResponseCacheService _responseCacheService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IResponseCacheService responseCacheService)
        {
            _logger = logger;
            _responseCacheService = responseCacheService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [Cache(1000)]
        public ActionResult<bool> Get(string keyWord, int pageIndex, int pageSize)
        {
            return Ok(true);
        }

        [HttpPost("Created")]
        public async Task<IActionResult> Created()
        {
            await _responseCacheService.RemoveResponseCacheAsync("/WeatherForecast");
            return Ok(true);
        }
    }
}