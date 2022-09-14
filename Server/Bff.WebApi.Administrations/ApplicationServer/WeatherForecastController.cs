using Bff.Domain.Model.Core.Framework;
using Bff.WebApi.Services.Teacher.Requests.Dto;
using Bff.WebApi.Services.Teacher.Requests.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ninject;

namespace Bff.WebApi.Services.Teacher.ApplicationServer
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHandlerFactory _handlerFactory;
        private readonly IExceptionHandler _exceptionHandler;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHandlerFactory handlerFactory, IExceptionHandler exceptionHandler)
        {
            _logger = logger;
            _handlerFactory = handlerFactory;
            _exceptionHandler = exceptionHandler;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult GetWeatherForecast()
        {
            var query = new GetWeatherForecastQuery
            {
            };

            var handler = _handlerFactory.GetQueryHandler<GetWeatherForecastQuery>();

            return _exceptionHandler.PerformGetOperation(() => handler.Execute(query));

        }
    }
}