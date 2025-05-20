using Microsoft.AspNetCore.Mvc;
using JwtAuthMinimalApi.Services;
using JwtAuthMinimalApi.Models;

namespace JwtAuthMinimalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public AuthController(JwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Username and password are required");
            }

            if (request.Username == "admin" && request.Password == "1234")
            {
                var token = _jwtTokenGenerator.GenerateToken(request.Username, request.Password);
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid username or password");
        }
    }
}