using Bff.Core.Framework;
using Bff.Core.Framework.Exceptions;
using Bff.WebApi.Services.Teacher.Requests.Commands;
using Ninject;

namespace Bff.WebApi.Services.Teacher.Handles.CommandHandlers
{
    internal class CreateWeatherForcastCommandHandler : CommandHandlerBase<CreateWeatherForcastCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        protected override object DoHandle(CreateWeatherForcastCommand command)
        {
            if (null == command.WeatherForecast)
                throw new ForbiddenException("Geen voor spelling door gegeven");

            return command.WeatherForecast;
        }
    }
}
