namespace JwtAuthMinimalApi.Services
{
    public interface IAuthorizationService
    {
        (bool Success, string? Token) Login(string username, string password);
    }
}