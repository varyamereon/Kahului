namespace Kahului.WeatherKit.Models;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum PrecipitationType
{
    /// <summary>
    /// No precipitation is occurring.
    /// </summary>
    [JsonPropertyName("clear")]
    Clear,
    /// <summary>
    /// An unknown type of precipitation is occuring.
    /// </summary>
    [JsonPropertyName("precipitation")]
    Precipitation,
    /// <summary>
    /// Rain or freezing rain is falling.
    /// </summary>
    [JsonPropertyName("rain")]
    Rain,
    /// <summary>
    /// Snow is falling.
    /// </summary>
    [JsonPropertyName("snow")]
    Snow,
    /// <summary>
    /// Sleet or ice pellets are falling.
    /// </summary>
    [JsonPropertyName("sleet")]
    Sleet,
    /// <summary>
    /// Hail is falling.
    /// </summary>
    [JsonPropertyName("hail")]
    Hail,
    /// <summary>
    /// Winter weather (wintery mix or wintery showers) is falling.
    /// </summary>
    [JsonPropertyName("mixed")]
    Mixed
}
