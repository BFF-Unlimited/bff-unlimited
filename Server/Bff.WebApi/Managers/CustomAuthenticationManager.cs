namespace Bff.WebApi.Managers
{
    public class CustomAuthenticationManager : ICustomAuthenticationManager
    {
        private readonly IDictionary<string, string> _users = new Dictionary<string, string>
        {
            { "Ans", "1234" },
            { "Marlies", "1234" },
            { "Willem", "1234" },
            { "test1", "password1" },
            { "test2", "password2" }
        };

        private readonly IDictionary<string, string> _tokens = new Dictionary<string, string>();

        public IDictionary<string, string> Tokens => _tokens;

        public string? Authenticate(string username, string password)
        {
            if (!_users.Any(u => u.Key == username && u.Value == password))
            {
                return null;
            }

            var token = Guid.NewGuid().ToString();

            _tokens.Add(token, username);

            return token;
        }
    }
}