namespace Kahului.WeatherKit;

internal partial class WeatherKit : IWeatherKit
{
    private readonly HttpClient _httpClient;

    public WeatherKit(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}