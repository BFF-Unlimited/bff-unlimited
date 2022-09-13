using Bff.Domain.Model.Core.Framework;
using Bff.WebApi.Services.Teacher.Requests.Dto;
using Bff.WebApi.Services.Teacher.Requests.Queries;

namespace Bff.WebApi.Services.Teacher.Handles.Queries
{
    internal class GetWeatherForecastQueryHandler : QueryHandlerBase<GetWeatherForecastQuery>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="query">The query to be executed.</param>
        /// <returns>Return a dto.</returns>
        protected override object DoExecute(GetWeatherForecastQuery query)
        {
            return Enumerable.Range(1, 5).Select(index =>
            {
                var a = new WeatherForecastDto();

                a.Date = DateTime.Now.AddDays(index);
                a.TemperatureC = Random.Shared.Next(-20, 55);
                a.Summary = Summaries[Random.Shared.Next(Summaries.Length)];
                return a;
            })
            .ToArray();
        }
    }
}
