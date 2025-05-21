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
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        private readonly IAuthorizationService _authorizationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="jwtTokenGenerator">Service to generate JWT tokens.</param>
        public AuthController(JwtTokenGenerator jwtTokenGenerator, IAuthorizationService authorizationService)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
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

            if (_authorizationService.ValidateCredentials(request.Username, request.Password))
            {
                var token = _jwtTokenGenerator.GenerateToken(request.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid username or password");
        }
    }
}