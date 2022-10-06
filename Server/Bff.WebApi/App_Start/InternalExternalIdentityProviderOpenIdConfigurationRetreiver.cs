using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Protocols;

namespace Bff.WebApi
{
    public class InternalExternalIdentityProviderOpenIdConfigurationRetreiver : IConfigurationRetriever<OpenIdConnectConfiguration>
    {
        private readonly IConfigurationRetriever<OpenIdConnectConfiguration> _defaultRetriever = new OpenIdConnectConfigurationRetriever();
        private readonly string _internalAddress;
        private readonly string _externalAddress;
        private readonly bool _isDevelopment;

        public InternalExternalIdentityProviderOpenIdConfigurationRetreiver(string internalAddress, string externalAddress, bool isDevelopment)
        {
            _internalAddress = internalAddress;
            _externalAddress = externalAddress;
            _isDevelopment = isDevelopment;
        }

        public async Task<OpenIdConnectConfiguration> GetConfigurationAsync(string address, IDocumentRetriever retriever, CancellationToken cancel)
        {
            if(retriever is HttpDocumentRetriever httpDocumentRetriever)
            {
                httpDocumentRetriever.RequireHttps = !_isDevelopment;
            }
            var configuration = await _defaultRetriever.GetConfigurationAsync(address, retriever, cancel);
            configuration.AuthorizationEndpoint = configuration.AuthorizationEndpoint.Replace(_internalAddress, _externalAddress);
            return configuration;
        }
    }
}