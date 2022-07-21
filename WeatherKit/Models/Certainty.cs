namespace Kahului.WeatherKit.Models;

/// <summary>
/// How likely the event is to occur.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum Certainty
{
    /// <summary>
    /// The event has already occurred or is ongoing.
    /// </summary>
    [JsonPropertyName("observed")]
    Observed,
    /// <summary>
    /// The event is likely to occur (greater than 50% probability).
    /// </summary>
    [JsonPropertyName("likely")]
    Likely,
    /// <summary>
    ///     The event is unlikley to occur (less than 50% probability).
    /// </summary>
    [JsonPropertyName("possible")]
    Possible,
    /// <summary>
    /// The event is not expected to occur (approximately 0% probability).
    /// </summary>
    [JsonPropertyName("unlikely")]
    Unlikely,
    /// <summary>
    /// It is unknown if the event will occur.
    /// </summary>
    [JsonPropertyName("unknown")]
    Unknown
}
