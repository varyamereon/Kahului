namespace Kahului.WeatherKit.Models;

/// <summary>
/// The shape of the moon as seen by an observer on the ground at a given time.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum MoonPhase
{
    /// <summary>
    /// The moon isn’t visible.
    /// </summary>
    [JsonPropertyName("new")]
    New,
    /// <summary>
    /// A crescent-shaped sliver of the moon is visible, and increasing in size.
    /// </summary>
    [JsonPropertyName("waxingCrescent")]
    WaxingCrescent,
    /// <summary>
    /// Approximately half of the moon is visible, and increasing in size.
    /// </summary>
    [JsonPropertyName("firstQuarter")]
    FirstQuarter,
    /// <summary>
    /// The entire disc of the moon is visible.
    /// </summary>
    [JsonPropertyName("full")]
    Full,
    /// <summary>
    /// More than half of the moon is visible, and increasing in size.
    /// </summary>
    [JsonPropertyName("waxingGibbous")]
    WaxingGibous,
    /// <summary>
    /// More than half of the moon is visible, and decreasing in size.
    /// </summary>
    [JsonPropertyName("waningGibbous")]
    WaningGibous,
    /// <summary>
    /// Approximately half of the moon is visible, and decreasing in size.
    /// </summary>
    [JsonPropertyName("thirdQuarter")]
    ThirdQuarter,
    /// <summary>
    /// A crescent-shaped sliver of the moon is visible, and decreasing in size.
    /// </summary>
    [JsonPropertyName("waningCrescent")]
    WaningCrescent
}
