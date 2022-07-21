namespace Kahului.WeatherKit.Models;

/// <summary>
/// A base type for all weather data.
/// </summary>
public class ProductData
{
    /// <summary>
    /// Descriptive information about the weather data.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Metadata? Metadata { get; set; }
}
