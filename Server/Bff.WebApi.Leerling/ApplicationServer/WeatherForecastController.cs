using Bff.Core.Framework;
using Bff.Core.Framework.Attributes;
using Bff.WebApi.Services.Teacher.Requests.Commands;
using Bff.WebApi.Services.Teacher.Requests.Dto;
using Bff.WebApi.Services.Teacher.Requests.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ninject;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Net;

namespace Bff.WebApi.Services.Teacher.ApplicationServer
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IHandlerFactory _handlerFactory;
        private readonly IExceptionHandler _exceptionHandler;

        public WeatherForecastController(IHandlerFactory handlerFactory, IExceptionHandler exceptionHandler)
        {
            _handlerFactory = handlerFactory;
            _exceptionHandler = exceptionHandler;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IList<WeatherForecastDto>), Description = "Alles oke")]
        [SwaggerResponse((int)HttpStatusCode.Forbidden, Description = "Dit mag niet")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Type = typeof(string), Description = "Niet ingelogd")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Verkeerde aanroep")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Er ging iets fout")]
        [SwaggerImplementationNotes("Geen")]
        public IActionResult GetWeatherForecast()
        {
            var query = new GetWeatherForecastQuery
            {
            };

            var handler = _handlerFactory.GetQueryHandler<GetWeatherForecastQuery>();

            return _exceptionHandler.PerformGetOperation(() => handler.Execute(query));
        }

        [HttpPut(Name = "CreateWeatherForecast")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(WeatherForecastDto), Description = "Alles oke")]
        [SwaggerResponse((int)HttpStatusCode.Forbidden, Description = "Dit mag niet")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Type = typeof(string), Description = "Niet ingelogd")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Verkeerde aanroep")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Er ging iets fout")]
        [SwaggerImplementationNotes("Geen")]
        public IActionResult CreateWeatherForecast([FromBody] WeatherForecastDto dto)
        {
            var query = new CreateWeatherForcastCommand
            {
                WeatherForecast = dto
            };

            var handler = _handlerFactory.GetCommandHandler<CreateWeatherForcastCommand>();

            return _exceptionHandler.PerformGetOperation(() => handler.Handle(query));
        }
    }
}