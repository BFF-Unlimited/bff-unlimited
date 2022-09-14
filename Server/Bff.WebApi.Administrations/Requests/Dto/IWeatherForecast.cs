namespace Bff.WebApi.Services.Administrations.Requests.Dto
{
    public interface IWeatherForecast
    {
        DateTime Date { get; set; }

        int TemperatureC { get; set; }

        int TemperatureF { get; }

        string? Summary { get; set; }
    }
}