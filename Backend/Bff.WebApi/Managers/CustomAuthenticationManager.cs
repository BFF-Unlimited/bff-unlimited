namespace Bff.WebApi.Managers
{
    public class CustomAuthenticationManager : ICustomAuthenticationManager
    {
        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        {
            { "Ans", "1234" },
            { "Marlies", "1234" },
            { "Willem", "1234" },
            { "test1", "password1" },
            { "test2", "password2" }
        };

        private readonly IDictionary<string, string> tokens = new Dictionary<string, string>();

        public IDictionary<string, string> Tokens => tokens;

        public string Authenticate(string username, string password)
        {
            if (!users.Any(u => u.Key == username && u.Value == password))
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }

            var token = Guid.NewGuid().ToString();

            tokens.Add(token, username);

            return token;
        }
    }
}