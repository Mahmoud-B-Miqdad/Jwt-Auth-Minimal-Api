using Microsoft.AspNetCore.Mvc;
using JwtAuthMinimalApi.Services;
using JwtAuthMinimalApi.Models;

namespace JwtAuthMinimalApi.Controllers
{
    /// <summary>
    /// Controller responsible for handling authentication-related endpoints.
    /// </summary>
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="jwtTokenGenerator">Service to generate JWT tokens.</param>
        public AuthController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        /// <summary>
        /// Authenticates the user with provided credentials and returns a JWT token if successful.
        /// </summary>
        /// <param name="request">The login request containing username and password.</param>
        /// <returns>
        /// 200 OK with JWT token on successful authentication,  
        /// 400 Bad Request if username or password is missing,  
        /// 401 Unauthorized if credentials are invalid.
        /// </returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Username and password are required");
            }

            var result = _authorizationService.Login(request.Username, request.Password);

            if (result.Success)
            {
                return Ok(new { Token = result.Token });
            }

            return Unauthorized("Invalid username or password");
        }

    }
}