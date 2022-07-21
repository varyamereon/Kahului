namespace Kahului.WeatherKit.Models;

/// <summary>
/// The hourly forecast information.
/// </summary>
public class HourlyForecast:ProductData
{
    /// <summary>
    /// An array of hourly forecasts.
    /// </summary>
    [JsonPropertyName("hours")]
    public List<HourWeatherConditions> Hours { get; set; } = new();
}
