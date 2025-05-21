using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller to test JWT authentication by providing a protected endpoint.
/// This endpoint requires a valid JWT token to access.
/// </summary>
[ApiController]
[Route("api/weather")]
[Authorize]
public class WeatherController : ControllerBase
{
    /// <summary>
    /// GET api/weather
    /// Returns a simple welcome message indicating the user is authorized.
    /// </summary>
    /// <returns>
    /// 200 OK with a welcome message and current date in UTC format.
    /// 401 Unauthorized if the JWT token is missing or invalid.
    /// </returns>
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