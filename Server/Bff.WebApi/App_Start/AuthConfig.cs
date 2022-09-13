using Bff.WebApi.Managers;
using Bff.WebApi.Handlers;

namespace Bff.WebApi
{ 
    public static class AuthConfig
    {
        public static void UseAuthentication(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication("Basic")
                .AddScheme<BasicAuthenticationOptions, CustomAuthenticationHandler>("Basic", null);

            builder.Services.AddSingleton<ICustomAuthenticationManager, CustomAuthenticationManager>();
        }

    }
}