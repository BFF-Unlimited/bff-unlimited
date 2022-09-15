using Bff.Core.Framework;
using Bff.Core.Framework.Exceptions;
using Bff.WebApi.Services.Administrations.Requests.Commands;

namespace Bff.WebApi.Services.Administrations.Handles.CommandHandlers
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
