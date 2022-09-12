using Microsoft.AspNetCore.SignalR;
using Ninject;

namespace Bff.WebApi
{
    internal sealed class NinjectHubActivator<THub> : IHubActivator<THub> where THub : Hub
    {
        private readonly IKernel kernel;

        public NinjectHubActivator(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public THub Create() => this.kernel.Get<THub>();

        public void Release(THub hub) => hub.Dispose();
    }
}
