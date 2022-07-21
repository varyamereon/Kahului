namespace Kahului.WeatherKit.Models;

/// <summary>
/// The daily forecast information.
/// </summary>
public class DailyForecast : ProductData
{
    /// <summary>
    /// An array of the day forecast weather conditions.
    /// </summary>
    [JsonPropertyName("days")]
    public List<DayWeatherConditions> Days { get; set; } = new();

    /// <summary>
    /// A URL that provides more information about the forecast.
    /// </summary>
    [JsonPropertyName("learnMoreURL")]
    public string? LearnMoreURL { get; set; }
}
