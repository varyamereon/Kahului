namespace Kahului.WeatherKit.Models;

/// <summary>
/// Optional parameters for making a weather request.
/// </summary>
public class WeatherQueryParameters
{
    /// <summary>
    /// The ISO Alpha-2 country code for the requested location. This parameter is necessary for weather alerts.
    /// </summary>
    public string? CountryCode { get; set; }

    /// <summary>
    /// The time to obtain current conditions. Defaults to now.
    /// </summary>
    public DateTime? CurrentAsOf { get; set; }

    /// <summary>
    /// The time to end the daily forecast. If this parameter is absent, daily forecasts run for 10 days.
    /// </summary>
    public DateTime? DailyEnd { get; set; }

    /// <summary>
    /// The time to start the daily forecast. If this parameter is absent, daily forecasts start on the current day.
    /// </summary>
    public DateTime? DailyStart { get; set; }

    /// <summary>
    /// A list of data sets to include in the response.
    /// </summary>
    public List<DataSet>? DataSets { get; set; }

    /// <summary>
    /// The time to end the hourly forecast. If this parameter is absent, hourly forecasts run 24 hours or the length of the daily forecast, whichever is longer.
    /// </summary>
    public DateTime? HourlyEnd { get; set; }

    /// <summary>
    /// The time to start the hourly forecast. If this parameter is absent, hourly forecasts start on the current hour.
    /// </summary>
    public DateTime? HourlyStart { get; set; }

    /// <summary>
    /// The name of the timezone to use for rolling up weather forecasts into daily forecasts.
    /// </summary>
    public string? TimeZone { get; set; }
}
