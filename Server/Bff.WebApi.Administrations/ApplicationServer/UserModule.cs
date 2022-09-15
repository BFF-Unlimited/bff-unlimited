using Bff.Core.Framework;
using Bff.Core.Framework.Handlers;
using Bff.WebApi.Services.Administrations.Handlers.QueryHandlers;
using Bff.WebApi.Services.Administrations.Requests.Queries;
using Ninject;

namespace Bff.WebApi.Services.Administrations.ApplicationServer
{
    public class UserModule : ModuleComposite
    {
        protected override void DoInitializeNinject(IKernel container)
        {
            container.Bind<IQueryHandler<GetActiveUserQuery>>().To<GetActiveUserQueryHandler>();
            container.Bind<IQueryHandler<GetUsersQuery>>().To<GetUsersQueryHandler>();
            container.Bind<IQueryHandler<GetUserQuery>>().To<GetUserQueryHandler>();
        }
    }
}
