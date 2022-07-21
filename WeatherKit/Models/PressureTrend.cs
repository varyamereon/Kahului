namespace Kahului.WeatherKit.Models;

/// <summary>
/// The direction of change of the sea level air pressure.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum PressureTrend
{
    /// <summary>
    /// The sea level air pressure is increasing.
    /// </summary>
    [JsonPropertyName("rising")]
    Rising,
    /// <summary>
    /// The sea level air pressure is decreasing.
    /// </summary>
    [JsonPropertyName("falling")]
    Falling,
    /// <summary>
    /// The sea level air pressure is remaining about the same.
    /// </summary>
    [JsonPropertyName("steady")]
    Steady
}
