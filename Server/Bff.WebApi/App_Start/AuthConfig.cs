using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Text.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.IdentityModel.Protocols;

namespace Bff.WebApi
{
    public static class AuthConfig
    {
        public static void AddIamAuthentication(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            services
                .AddAuthentication(options =>
            {
                options.DefaultScheme = "cookie";
                options.DefaultChallengeScheme = "oidc";
                options.DefaultSignOutScheme = "oidc";
            })
            .AddCookie(
                "cookie",
                options =>
                {
                    // set session lifetime
                    options.ExpireTimeSpan = TimeSpan.FromHours(8);

                    // sliding or absolute
                    options.SlidingExpiration = false;

                    // host prefixed cookie name
                    options.Cookie.Name = "Esis.Shin-Host-web";

                    // strict SameSite handling
                    options.Cookie.SameSite = SameSiteMode.None;
                }
            )
            .AddOpenIdConnect(
                "oidc",
                options =>
                {
                    options.Authority = configuration["Authentication:ExternalUrl"];
                    options.MetadataAddress = configuration["Authentication:InternalUrl"] + "/.well-known/openid-configuration";
                    options.ConfigurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                        options.MetadataAddress, 
                        new InternalExternalIdentityProviderOpenIdConfigurationRetreiver(configuration["Authentication:InternalUrl"], configuration["Authentication:ExternalUrl"], isDevelopment));
                    options.RequireHttpsMetadata = !isDevelopment;

                    // confidential client using code flow + PKCE
                    options.ClientId = configuration["Authentication:ClientId"];
                    options.ClientSecret = configuration["Authentication:ClientSecret"];
                    options.ResponseType = "code";

                    // query response type is compatible with strict SameSite mode
                    options.ResponseMode = OpenIdConnectResponseMode.FormPost;

                    // get claims without mappings
                    options.MapInboundClaims = false;
                    options.GetClaimsFromUserInfoEndpoint = true;

                    options.Events.OnUserInformationReceived = async context =>
                    {
                        var additionalClaims = context.User.Deserialize<IDictionary<string, string>>();
                        if(
                            additionalClaims != null
                            && context.Principal!.Identity is ClaimsIdentity ingelogdeGebruiker
                        )
                        {
                            ingelogdeGebruiker.AddClaims(
                                additionalClaims.Select(c => new Claim(c.Key, c.Value))
                            );
                        }
                    };

                    // save tokens into authentication session
                    // to enable automatic token management
                    options.SaveTokens = true;

                    // request scopes
                    options.Scope.Clear();
                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("api");
                    options.Scope.Add("rollen");

                    // and refresh token
                    options.Scope.Add("offline_access");
                }
            );
            services.AddBff(options =>
            {
                // default value
                options.ManagementBasePath = "/bff";
                options.AntiForgeryHeaderName = "x-csrf";
                options.AntiForgeryHeaderValue = "1";
            });
        }
    }

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