using System.Security.Claims;

namespace JwtAuthMinimalApi.Services
{
    /// <summary>
    /// Defines methods to generate and validate JSON Web Tokens (JWT).
    /// </summary>
    public interface IJwtTokenGenerator
    {
        /// <summary>
        /// Generates a signed JWT token for the specified username.
        /// </summary>
        /// <param name="username">The username for whom the token will be generated.</param>
        /// <returns>A signed JWT token string.</returns>
        string GenerateToken(string username);

        /// <summary>
        /// Validates the specified JWT token and returns the associated claims principal if the token is valid.
        /// </summary>
        /// <param name="token">The JWT token string to validate.</param>
        /// <returns>
        /// A <see cref="ClaimsPrincipal"/> representing the token's claims if valid; otherwise, <c>null</c>.
        /// </returns>
        ClaimsPrincipal? ValidateToken(string token);
    }
}