using Esis.Shin.Core.Framework;
using Esis.Shin.Core.Framework.Handlers;
using Esis.Shin.Services.Administrations.Handlers.QueryHandlers;
using Esis.Shin.Services.Administrations.Requests.Queries;
using Ninject;

namespace Esis.Shin.Services.Administrations.ApplicationServer
{
    public class UserModule : ModuleComposite
    {
        protected override void DoInitializeNinject(IKernel container)
        {
            container.Bind<IAsyncQueryHandler<GetActiveUserQuery>>().To<GetActiveUserQueryHandler>();
            container.Bind<IAsyncQueryHandler<GetUsersQuery>>().To<GetUsersQueryHandler>();
            container.Bind<IAsyncQueryHandler<GetUserQuery>>().To<GetUserQueryHandler>();
        }
    }
}
