namespace JwtAuthMinimalApi.Models
{
    /// <summary>
    /// Represents login request payload with username and password.
    /// </summary>
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
