using Bff.Core.Framework;
using Bff.WebApi.Services.Administrations.Requests.Dto;
using Bff.WebApi.Services.Administrations.Requests.Queries;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bff.WebApi.Services.Administrations.Handles.Queries
{
    internal class GetWeatherForecastQueryHandler : QueryHandlerBase<GetWeatherForecastQuery>
    {
        private static readonly string[] _Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IKernel _kernel;

        public GetWeatherForecastQueryHandler(IKernel kernel)
        {
            _kernel = kernel;
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="query">The query to be executed.</param>
        /// <returns>Return a dto.</returns>
        protected override object DoExecute(GetWeatherForecastQuery query)
        {
            return Enumerable.Range(1, 5).Select(index =>
            {
                var a = _kernel.Get<IWeatherForecast>();

                a.Date = DateTime.Now.AddDays(index);
                a.TemperatureC = Random.Shared.Next(-20, 55);
                a.Summary = _Summaries[Random.Shared.Next(_Summaries.Length)];
                return a;
            })
            .ToArray();
        }
    }
}
