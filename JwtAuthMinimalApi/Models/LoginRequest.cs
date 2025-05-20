namespace JwtAuthMinimalApi.Models
{
    /// <summary>
    /// Represents the login request payload sent by the client.
    /// Contains the username and password for authentication.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// The username of the user attempting to authenticate.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password of the user.
        /// </summary>
        public string Password { get; set; }
    }
}