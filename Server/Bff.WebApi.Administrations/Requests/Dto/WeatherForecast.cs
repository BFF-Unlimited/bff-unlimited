using Bff.WebApi.Services.Administrations.Requests.Dto;

namespace Bff.WebApi.Services.Teacher.Requests.Dto
{
    public class WeatherForecast : IWeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}