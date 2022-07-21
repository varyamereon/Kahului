namespace Kahului.WeatherKit.Models;

/// <summary>
/// The collection of all requested weather data.
/// </summary>
public class Weather
{
    /// <summary>
    /// The current weather for the requested location.
    /// </summary>
    [JsonPropertyName("currentWeather")]
    public CurrentWeather? CurrentWeather { get; set; }

    /// <summary>
    /// The daily forecast for the requested location.
    /// </summary>
    [JsonPropertyName("forecastDaily")]
    public DailyForecast? ForecastDaily { get; set; }

    /// <summary>
    /// The hourly forecast for the requested location.
    /// </summary>
    [JsonPropertyName("forecastHourly")]
    public HourlyForecast? ForecastHourly { get; set; }

    /// <summary>
    /// The next hour forecast for the requested location.
    /// </summary>
    [JsonPropertyName("forecastNextHour")]
    public NextHourForecast? ForecastNextHour { get; set; }

    /// <summary>
    /// Weather alerts for the requested location.
    /// </summary>
    [JsonPropertyName("weatherAlerts")]
    public WeatherAlertCollection? WeatherAlerts { get; set; }
}
