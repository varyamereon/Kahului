namespace Kahului.WeatherKit.Models;

/// <summary>
/// An official message indicating severe weather from a reporting agency.
/// </summary>
public class WeatherAlert : WeatherAlertSummary
{
    /// <summary>
    /// An object defining the geographic region the weather alert applies to.
    /// </summary>
    [JsonPropertyName("area")]
    public JsonElement? Area { get; set; }

    /// <summary>
    /// An array of official text messages describing a severe weather event from the agency.
    /// </summary>
    [JsonPropertyName("messages")]
    public List<EventText> Messages { get; set; } = new();
}
