using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Bff.WebApi.Tests
{
    public class ServerApiFixture
    {
        public Uri ServerUri { get; }

        public ServerApiFixture()
        {
            var task = Program.Main(null);
            _ = task.GetAwaiter();
            _ = task.Wait(4000);
            ServerUri = new Uri(Program.ServerUrl);
        }
    }
}
