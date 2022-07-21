namespace Kahului.WeatherKit.Models;

/// <summary>
/// The recommended action from a reporting agency.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum ResponseType
{
    /// <summary>
    /// Take shelter in place.
    /// </summary>
    [JsonPropertyName("shelter")]
    Shelter,
    /// <summary>
    /// Relocate.
    /// </summary>
    [JsonPropertyName("evacuate")]
    Evacuate,
    /// <summary>
    /// Make preparations.
    /// </summary>
    [JsonPropertyName("prepare")]
    Prepare,
    /// <summary>
    /// Execute a pre-planned activity.
    /// </summary>
    [JsonPropertyName("execute")]
    Execute,
    /// <summary>
    /// Avoid the event.
    /// </summary>
    [JsonPropertyName("avoid")]
    Avoid,
    /// <summary>
    /// Monitor the situation.
    /// </summary>
    [JsonPropertyName("monitor")]
    Monitor,
    /// <summary>
    /// Assess the situation.
    /// </summary>
    [JsonPropertyName("assess")]
    Assess,
    /// <summary>
    /// The event no longer poses a threat.
    /// </summary>
    [JsonPropertyName("allClear")]
    AllClear,
    /// <summary>
    /// No action recommended.
    /// </summary>
    [JsonPropertyName("none")]
    None
}
