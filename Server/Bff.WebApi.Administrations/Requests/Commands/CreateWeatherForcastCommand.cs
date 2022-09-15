using Bff.WebApi.Services.Administrations.Requests.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bff.WebApi.Services.Administrations.Requests.Commands
{
    internal class CreateWeatherForcastCommand
    {
        public WeatherForecastDto? WeatherForecast { get; set; }
    }
}
