namespace Kahului.WeatherKit.Models;

/// <summary>
/// The system of units that the weather data is reported in.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum UnitsSystem
{
    /// <summary>
    /// The metric system.
    /// </summary>
    [JsonPropertyName("m")]
    Metric
}
