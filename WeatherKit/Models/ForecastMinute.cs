namespace Kahului.WeatherKit.Models;

/// <summary>
/// The precipitation forecast for a specified minute.
/// </summary>
public class ForecastMinute
{
    /// <summary>
    /// The probability of precipitation during this minute.
    /// </summary>
    [JsonPropertyName("precipitationChance")]
    public double PrecipitationChance { get; set; }

    /// <summary>
    /// The precipitation intensity in millimeters per hour.
    /// </summary>
    [JsonPropertyName("precipitationIntensity")]
    public double PrecipitationIntensity { get; set; }

    /// <summary>
    /// The start time of the minute.
    /// </summary>
    [JsonPropertyName("startTime")]
    public DateTime StartTime { get; set; }
}
