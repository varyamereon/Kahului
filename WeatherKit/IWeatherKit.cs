namespace Kahului.WeatherKit;
public interface IWeatherKit
{
    /// <summary>
    /// Determine the data sets available for the specified location.
    /// </summary>
    /// <see cref="https://developer.apple.com/documentation/weatherkitrestapi/get_api_v1_availability_latitude_longitude"/>
    /// <param name="latitude">The latitude of the desired location.</param>
    /// <param name="longitude">The latitude of the desired location.</param>
    Task<List<DataSet>> GetAvailableDataSetsAsync(double latitude, double longitude);

    /// <summary>
    /// Determine the data sets available for the specified location.
    /// </summary>
    /// <see cref="https://developer.apple.com/documentation/weatherkitrestapi/get_api_v1_availability_latitude_longitude"/>
    /// <param name="latitude">The latitude of the desired location.</param>
    /// <param name="longitude">The latitude of the desired location.</param>
    /// <param name="country">The ISO Alpha-2 country code for the requested location. This parameter is necessary for air quality and weather alerts.</param>
    Task<List<DataSet>> GetAvailableDataSetsAsync(double latitude, double longitude, string country);

    /// <summary>
    /// Obtain weather data for the specified location.
    /// </summary>
    /// <see cref="https://developer.apple.com/documentation/weatherkitrestapi/get_api_v1_weather_language_latitude_longitude"/>
    /// <param name="language">The language tag to use for localizing responses.</param>
    /// <param name="latitude">The latitude of the desired location.</param>
    /// <param name="longitude">The longitude of the desired location.</param>
    Task<Weather> GetWeatherAsync(string language, double latitude, double longitude);

    /// <summary>
    /// Obtain weather data for the specified location.
    /// </summary>
    /// <see cref="https://developer.apple.com/documentation/weatherkitrestapi/get_api_v1_weather_language_latitude_longitude"/>
    /// <param name="language">The language tag to use for localizing responses.</param>
    /// <param name="latitude">The latitude of the desired location.</param>
    /// <param name="longitude">The longitude of the desired location.</param>
    /// <param name="countryCode">The ISO Alpha-2 country code for the requested location. This parameter is necessary for weather alerts.</param>
    Task<Weather> GetWeatherAsync(string language, double latitude, double longitude, string countryCode);

    /// <summary>
    /// Obtain weather data for the specified location.
    /// </summary>
    /// <see cref="https://developer.apple.com/documentation/weatherkitrestapi/get_api_v1_weather_language_latitude_longitude"/>
    /// <param name="language">The language tag to use for localizing responses.</param>
    /// <param name="latitude">The latitude of the desired location.</param>
    /// <param name="longitude">The longitude of the desired location.</param>
    /// <param name="parameters">The optional parameters to include in the weather request.</param>
    Task<Weather> GetWeatherAsync(string language, double latitude, double longitude, WeatherQueryParameters parameters);

    /// <summary>
    /// Receive an active weather alert.
    /// </summary>
    /// <param name="id">The unique identifier for the weather alert.</param>
    /// <param name="language">The language tag to use for localizing responses.</param>
    Task<WeatherAlert> GetWeatherAlertAsync(string id, string language);
}
