using Bff.Core.Framework;
using Bff.Core.Framework.Handlers;
using Bff.WebApi.Services.Administrations.Handles.CommandHandlers;
using Bff.WebApi.Services.Administrations.Handles.QueryHandlers;
using Bff.WebApi.Services.Administrations.Requests.Commands;
using Bff.WebApi.Services.Administrations.Requests.Queries;
using Ninject;

namespace Bff.WebApi.Services.Teacher.ApplicationServer
{
    public class WeatherForecastModule : ModuleComposite
    {
        protected override void DoInitializeNinject(IKernel container)
        {
            container.Bind<IQueryHandler<GetWeatherForecastQuery>>().To<GetWeatherForecastQueryHandler>();
            container.Bind<ICommandHandler<CreateWeatherForcastCommand>>().To<CreateWeatherForcastCommandHandler>();
        }
    }
}
