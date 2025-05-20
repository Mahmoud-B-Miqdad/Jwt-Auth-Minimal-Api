
namespace JwtAuthMinimalApi.Configurations;

/// <summary>
/// Represents the configuration settings required for JWT token generation and validation.
/// </summary>
public class JwtSettings
{
    /// <summary>
    /// The secret key used to sign the JWT tokens.
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// The issuer of the JWT token. Typically, the authentication server or application name.
    /// </summary>
    public string Issuer { get; set; }

    /// <summary>
    /// The intended audience for the JWT token.
    /// </summary>
    public string Audience { get; set; }
}