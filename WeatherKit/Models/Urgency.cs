namespace Kahului.WeatherKit.Models;

/// <summary>
/// An indication of urgency of action from the reporting agency.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum Urgency
{
    /// <summary>
    /// Take responsive action immediately.
    /// </summary>
    [JsonPropertyName("immediate")]
    Immediate,
    /// <summary>
    /// Take responsive action in the next hour.
    /// </summary>
    [JsonPropertyName("expected")]
    Expected,
    /// <summary>
    /// Take responsive action in the near future.
    /// </summary>
    [JsonPropertyName("future")]
    Future,
    /// <summary>
    /// Responsive action is no longer required.
    /// </summary>
    [JsonPropertyName("past")]
    Past,
    /// <summary>
    /// The urgency is unknown.
    /// </summary>
    [JsonPropertyName("unknown")]
    Unknown
}
