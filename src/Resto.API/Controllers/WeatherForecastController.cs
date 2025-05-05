using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Resto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Weather is sunny");
    }
}
