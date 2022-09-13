using Bff.Core.Framework;
using Bff.WebApi.Services.Administrations.Handles.CommandHandlers;
using Bff.WebApi.Services.Administrations.Handles.Queries;
using Bff.WebApi.Services.Administrations.Requests.Dto;
using Bff.WebApi.Services.Administrations.Requests.Queries;
using Bff.WebApi.Services.Teacher.Requests.Dto;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
