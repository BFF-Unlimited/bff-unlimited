using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Esis.Shin.Tests
{
    public class ServerApiFixture
    {
        public Uri ServerUri { get; } = new Uri("http://127.0.0.1:5000");

        public ServerApiFixture()
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(
                    webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                        webBuilder.UseUrls(ServerUri.ToString());
                    }).Build();

            host.RunAsync();
        }
    }
}
