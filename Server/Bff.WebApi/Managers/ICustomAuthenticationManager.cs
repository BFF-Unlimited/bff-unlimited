using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Bff.WebApi;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Identity;
using Ninject.Activation;
using System.Security.Cryptography;
using System;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Bff.WebApi.Managers
{
    public interface ICustomAuthenticationManager
    {
        Task<string?> Authenticate(string username, string password);

        IDictionary<string, string> Tokens { get; }
    }
}