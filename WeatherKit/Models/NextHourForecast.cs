﻿namespace Kahului.WeatherKit.Models;

/// <summary>
/// The next hour forecast information.
/// </summary>
public class NextHourForecast:ProductData
{
    /// <summary>
    /// The time the forecast ends.
    /// </summary>
    [JsonPropertyName("forecastEnd")]
    public DateTime? ForecastEnd { get; set; }

    /// <summary>
    /// The time the forecast starts.
    /// </summary>
    [JsonPropertyName("forecastStart")]
    public DateTime? ForecastStart { get; set; }

    /// <summary>
    /// An array of the forecast minutes.
    /// </summary>
    [JsonPropertyName("minutes")]
    public List<ForecastMinute> Minutes { get; set; } = new();

    /// <summary>
    /// An array of the forecast summaries.
    /// </summary>
    [JsonPropertyName("summary")]
    public List<ForecastPeriodSummary> Summary { get; set; } = new();
}