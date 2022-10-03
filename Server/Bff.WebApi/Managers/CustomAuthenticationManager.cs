using Bff.WebApi.Services.Administrations.DataAccess.Mysql;

namespace Bff.WebApi.Managers
{
    public class CustomAuthenticationManager : ICustomAuthenticationManager
    {

        private readonly IDictionary<string, string> _tokens = new Dictionary<string, string>();

        public IDictionary<string, string> Tokens => _tokens;
        private readonly IAdministrationContext _administrationContext;

        public CustomAuthenticationManager(IAdministrationContext administrationContext)
        {
            _administrationContext = administrationContext;
        }

        public async Task<string?> Authenticate(string username, string password)
        {
            var user = await _administrationContext.GetUser(username, password);
            if(user == null) return null;

            var token = Guid.NewGuid().ToString();
            _tokens.Add(token, username);
            
            return token;
        }
    }
}