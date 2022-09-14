namespace Bff.WebApi.Services.Teacher.Requests.Dto
{
    public interface IWeatherForecast
    {
        DateTime Date { get; set; }

        int TemperatureC { get; set; }

        int TemperatureF { get; }

        string? Summary { get; set; }
    }
}