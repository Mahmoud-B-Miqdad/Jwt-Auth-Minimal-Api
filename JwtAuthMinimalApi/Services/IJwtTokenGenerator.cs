using System.Security.Claims;

namespace JwtAuthMinimalApi.Services
{
    public interface IJwtTokenGenerator
    {
        /// <summary>
        /// Generates a JWT token for the given username.
        /// </summary>
        /// <param name="username">Username for whom the token is generated</param>
        /// <returns>Signed JWT token string</returns>
        string GenerateToken(string username);

        /// <summary>
        /// Validates the given JWT token and returns the principal if valid.
        /// </summary>
        /// <param name="token">JWT token string</param>
        /// <returns>ClaimsPrincipal if valid, otherwise null</returns>
        ClaimsPrincipal? ValidateToken(string token);
    }
}