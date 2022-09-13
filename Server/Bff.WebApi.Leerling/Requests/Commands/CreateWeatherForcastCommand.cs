using Bff.WebApi.Services.Teacher.Requests.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bff.WebApi.Services.Teacher.Requests.Commands
{
    internal class CreateWeatherForcastCommand
    {
        public WeatherForecastDto? WeatherForecast { get; set; }
    }
}
