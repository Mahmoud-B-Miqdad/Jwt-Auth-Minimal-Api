namespace JwtAuthMinimalApi.Services
{
    public class AuthorizationService : IAuthorizationService
    {

        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthorizationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public bool ValidateCredentials(string username, string password)
        {
            return username == "admin" && password == "1234";
        }

        public (bool Success, string? Token) Login(string username, string password)
        {
            if (ValidateCredentials(username, password))
            {
                var token = _jwtTokenGenerator.GenerateToken(username);
                return (true, token);
            }

            return (false, null);
        }
    }

}