using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtAuthMinimalApi.Configurations;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthMinimalApi.Services
{
    /// <summary>
    /// Responsible for generating and validating JWT tokens.
    /// Uses symmetric key signing with HMAC SHA256 algorithm.
    /// </summary>
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;

        /// <summary>
        /// Initializes a new instance of <see cref="JwtTokenGenerator"/> using the specified JWT settings.
        /// </summary>
        /// <param name="jwtSettings">An object containing the secret key, issuer, and audience used for generating JWT tokens.</param>
        public JwtTokenGenerator(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        /// <summary>
        /// Generates a signed JWT token for the specified username.
        /// The token includes standard claims like subject and unique identifier,
        /// and expires 1 hour after creation.
        /// </summary>
        /// <param name="username">The username for whom the token is generated.</param>
        /// <returns>A signed JWT token string.</returns>
        public string GenerateToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Validates the specified JWT token and returns the claims principal if valid.
        /// Validation includes checking issuer, audience, signing key, and token expiration.
        /// Returns null if the token is invalid or expired.
        /// </summary>
        /// <param name="token">The JWT token string to validate.</param>
        /// <returns>
        /// A <see cref="ClaimsPrincipal"/> representing the token's claims if valid; otherwise, <c>null</c>.
        /// </returns>
        public ClaimsPrincipal? ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);

            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = _jwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = _jwtSettings.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return principal;
            }
            catch
            {
                // Token validation failed
                return null;
            }
        }
    }
}
