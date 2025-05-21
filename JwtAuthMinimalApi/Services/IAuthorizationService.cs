namespace JwtAuthMinimalApi.Services
{
    public interface IAuthorizationService
    {
        bool ValidateCredentials(string username, string password);
    }

}