using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Globalization;
using Ninject.Activation;
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