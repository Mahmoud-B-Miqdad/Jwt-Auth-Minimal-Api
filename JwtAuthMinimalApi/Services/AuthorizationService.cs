namespace JwtAuthMinimalApi.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        public bool ValidateCredentials(string username, string password)
        {
            return username == "admin" && password == "1234";
        }
    }

}