namespace Kahului.WeatherKit.Models;

/// <summary>
/// The level of danger to life and property.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum Severity
{
    /// <summary>
    /// Extraordinary threat.
    /// </summary>
    [JsonPropertyName("extreme")]
    Extreme,
    /// <summary>
    /// Significant threat.
    /// </summary>
    [JsonPropertyName("severe")]
    Severe,
    /// <summary>
    /// Possible threat.
    /// </summary>
    [JsonPropertyName("moderate")]
    Moderate,
    /// <summary>
    /// Minimal or no known threat.
    /// </summary>
    [JsonPropertyName("minor")]
    Minor,
    /// <summary>
    /// Unknown threat.
    /// </summary>
    [JsonPropertyName("unknown")]
    Unknown
}
