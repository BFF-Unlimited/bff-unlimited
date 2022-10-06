using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Text.Json;
using System.Security.Claims;
using Microsoft.IdentityModel.Protocols;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace Esis.Shin
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
                    options.Cookie.SameSite = SameSiteMode.Strict;
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                }
            )
            .AddOpenIdConnect(
                "oidc",
                options =>
                {
                    var internalAddress = configuration["Authentication:InternalUrl"];
                    var externalAddress = configuration["Authentication:ExternalUrl"];
                    options.Authority = externalAddress;
                    options.MetadataAddress = $"{internalAddress}/.well-known/openid-configuration";
                    options.ConfigurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                        options.MetadataAddress,
                        new InternalExternalIdentityProviderOpenIdConfigurationRetreiver(internalAddress, externalAddress, isDevelopment));
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

                    options.Events.OnUserInformationReceived = ZetEigenClaimsInDeIngelogdeIdentity;

                    // save tokens into authentication session
                    // to enable automatic token management
                    options.SaveTokens = true;

                    // request scopes
                    options.Scope.Clear();
                    foreach(var scope in GebruikersprofielEnEsisInformatie)
                        options.Scope.Add(scope);

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

        private static Task ZetEigenClaimsInDeIngelogdeIdentity(UserInformationReceivedContext context)
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

            return Task.CompletedTask;
        }

        private static IEnumerable<string> GebruikersprofielEnEsisInformatie => new[] { "openid", "profile", "api", "rollen" };


        public static void UseIamAuthentication(this IApplicationBuilder app)
        {
            app.UseBff();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapBffManagementEndpoints());
        }
    }
}