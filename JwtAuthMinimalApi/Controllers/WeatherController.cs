using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthMinimalApi.Controllers
{
    /// <summary>
    /// Controller to test JWT authentication by providing a protected endpoint.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] 
    public class WeatherController : ControllerBase
    {
        /// <summary>
        /// GET api/weather
        /// Returns a simple welcome message indicating the user is authorized.
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Message = "Welcome! You are authorized to access this endpoint.",
                Date = System.DateTime.UtcNow.ToString("yyyy-MM-dd")
            });
        }
    }
}
