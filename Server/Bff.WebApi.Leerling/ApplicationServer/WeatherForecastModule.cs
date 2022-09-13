using Bff.Domain.Model.Core.Framework;
using Bff.WebApi.Services.Teacher.Handles.CommandHandlers;
using Bff.WebApi.Services.Teacher.Handles.Queries;
using Bff.WebApi.Services.Teacher.Requests.Commands;
using Bff.WebApi.Services.Teacher.Requests.Dto;
using Bff.WebApi.Services.Teacher.Requests.Queries;
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
