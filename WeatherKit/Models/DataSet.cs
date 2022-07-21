namespace Kahului.WeatherKit.Models;

/// <summary>
/// The collection of weather information for a location.
/// </summary>
public enum DataSet
{
    /// <summary>
    /// The current weather for the requested location.
    /// </summary>
    CurrentWeather,
    /// <summary>
    /// The daily forecast for the requested location.
    /// </summary>
    ForecastDaily,
    /// <summary>
    /// The hourly forecast for the requested location.
    /// </summary>
    ForecastHourly,
    /// <summary>
    /// The next hour forecast for the requested location.
    /// </summary>
    ForecastNextHour,
    /// <summary>
    /// Weather alerts for the requested location.
    /// </summary>
    WeatherAlerts
}

internal static class DataSetExtensions
{
    internal static List<DataSet> ToEnumList(this List<string> dataSetStrings)
    {
        var list = new List<DataSet>();

        foreach (var dataSetString in dataSetStrings)
        {
            var dataSet = dataSetString switch
            {
                "currentWeather" => DataSet.CurrentWeather,
                "forecastDaily" => DataSet.ForecastDaily,
                "forecastHourly" => DataSet.ForecastHourly,
                "forecastNextHour" => DataSet.ForecastNextHour,
                "weatherAlerts" => DataSet.WeatherAlerts,
                _ => throw new Exception($"The string '{dataSetString}' is not a valid DataSet.")
            };

            list.Add(dataSet);
        }

        return list;
    }

    internal static string ToCommaDelimitedString(this IEnumerable<DataSet> dataSets)
    {
        var list = new List<string>();

        foreach (var dataSet in dataSets)
        {
            var dataSetString = dataSet switch
            {
                DataSet.CurrentWeather => "currentWeather",
                DataSet.ForecastDaily => "forecastDaily",
                DataSet.ForecastHourly => "forecastHourly",
                DataSet.ForecastNextHour => "forecastNextHour",
                DataSet.WeatherAlerts => "weatherAlerts",
                _ => throw new Exception($"The enum '{dataSet}' is not a valid DataSet."),
            };

            list.Add(dataSetString);
        }

        return string.Join(",", list);
    }
}