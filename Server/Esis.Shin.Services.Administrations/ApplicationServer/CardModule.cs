using Esis.Shin.Core.Framework;
using Esis.Shin.Core.Framework.Handlers;
using Esis.Shin.Services.Administrations.Handlers.QueryHandlers;
using Esis.Shin.Services.Administrations.Requests.Queries;
using Ninject;

namespace Esis.Shin.Services.Administrations.ApplicationServer
{
    public class CardModule : ModuleComposite
    {
        protected override void DoInitializeNinject(IKernel container)
        {
            container.Bind<IAsyncQueryHandler<GetCardsDataQuery>>().To<GetCardsDataQueryHandler>();
        }
    }
}
