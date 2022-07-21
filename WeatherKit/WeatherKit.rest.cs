#if !IOS16_0_OR_GREATER && !MACCATALYST16_0_OR_GREATER

using System.Collections.Specialized;
using System.Diagnostics.Metrics;
using System.Web;

namespace Kahului.WeatherKit;

internal partial class WeatherKit
{
    #region DataSets

    public async Task<List<DataSet>> GetAvailableDataSetsAsync(double latitude, double longitude)
    {
        if (latitude<-90 || latitude > 90)
        {
            throw new ArgumentException("Latitude was invalid.");
        }

        if (longitude<-180 || longitude > 180)
        {
            throw new ArgumentException("Longitude was invalid.");
        }

        var url = $"availability/{latitude}/{longitude}";
        return await GetAvailableDataSetsAsync(url).ConfigureAwait(false);

    }

    public async Task<List<DataSet>> GetAvailableDataSetsAsync(double latitude, double longitude, string country)
    {
        if (latitude < -90 || latitude > 90)
        {
            throw new ArgumentException("Latitude was invalid.");
        }

        if (longitude < -180 || longitude > 180)
        {
            throw new ArgumentException("Longitude was invalid.");
        }

        if (string.IsNullOrEmpty(country) || country.Length != 2)
        {
            throw new ArgumentException("Country was invalid.");
        }

        var url = $"availability/{latitude}/{longitude}?country={country}";
        return await GetAvailableDataSetsAsync(url).ConfigureAwait(false);
    }

    private async Task<List<DataSet>> GetAvailableDataSetsAsync(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        return JsonSerializer.Deserialize<List<string>>(json)?
            .ToEnumList() ?? new();
    }

    #endregion

    #region Weather

    public async Task<Weather> GetWeatherAsync(string language, double latitude, double longitude)
    {
        if (string.IsNullOrEmpty(language))
        {
            throw new ArgumentException("Language was invalid.");
        }

        if (latitude < -90 || latitude > 90)
        {
            throw new ArgumentException("Latitude was invalid.");
        }

        if (longitude < -180 || longitude > 180)
        {
            throw new ArgumentException("Longitude was invalid.");
        }

        var url = $"weather/{language}/{latitude}/{longitude}?dataSets=currentWeather,forecastDaily,forecastHourly,forecastNextHour";

        return await GetWeatherAsync(url).ConfigureAwait(false);
    }

    public async Task<Weather> GetWeatherAsync(string language, double latitude, double longitude, string countryCode)
    {
        if (string.IsNullOrEmpty(language))
        {
            throw new ArgumentException("Language was invalid.");
        }

        if (latitude < -90 || latitude > 90)
        {
            throw new ArgumentException("Latitude was invalid.");
        }

        if (longitude < -180 || longitude > 180)
        {
            throw new ArgumentException("Longitude was invalid.");
        }

        if (string.IsNullOrEmpty(countryCode) || countryCode.Length != 2)
        {
            throw new ArgumentException("Country was invalid.");
        }

        var url = $"weather/{language}/{latitude}/{longitude}?dataSets=currentWeather,forecastDaily,forecastHourly,forecastNextHour,weatherAlerts&country={countryCode}";

        return await GetWeatherAsync(url).ConfigureAwait(false);
    }

    public async Task<Weather> GetWeatherAsync(string language, double latitude, double longitude, WeatherQueryParameters parameters)
    {
        if (string.IsNullOrEmpty(language))
        {
            throw new ArgumentException("Language was invalid.");
        }

        if (latitude < -90 || latitude > 90)
        {
            throw new ArgumentException("Latitude was invalid.");
        }

        if (longitude < -180 || longitude > 180)
        {
            throw new ArgumentException("Longitude was invalid.");
        }

        var url = $"weather/{language}/{latitude}/{longitude}";
        var queryString = HttpUtility.ParseQueryString(string.Empty);

        if (parameters.DataSets is not null && parameters.DataSets.Count > 0)
        {
            var hashedList = new HashSet<DataSet>(parameters.DataSets);
            var dataSets = hashedList.ToCommaDelimitedString();
            queryString.Add("dataSets", dataSets);
        }
        // With no data sets the weather object would be empty so we just return an empty
        // weather object without making the call to the server.
        else return new();

        if (parameters.CountryCode is not null)
        {
            if (!string.IsNullOrEmpty(parameters.CountryCode) && parameters.CountryCode.Length == 2)
            {
                queryString.Add("countryCode", parameters.CountryCode);
            }
            else
            {
                throw new ArgumentException("Country code was invalid.");
            }
        }

        if (parameters.CurrentAsOf is not null)
        {
            queryString.Add("currentAsOf", parameters.CurrentAsOf?.ToUniversalTime().ToString("O"));
        }

        if (parameters.DailyEnd is not null)
        {
            queryString.Add("dailyEnd", parameters.DailyEnd?.ToUniversalTime().ToString("O"));
        }

        if (parameters.DailyStart is not null)
        {
            queryString.Add("dailyStart", parameters.DailyStart?.ToUniversalTime().ToString("O")); 
        }

        if (parameters.HourlyEnd is not null)
        {
            queryString.Add("hourlyEnd", parameters.DailyStart?.ToUniversalTime().ToString("O"));
        }

        if (parameters.HourlyStart is not null)
        {
            queryString.Add("hourlyStart", parameters.HourlyStart?.ToUniversalTime().ToString("O"));
        }

        if (!string.IsNullOrEmpty(parameters.TimeZone))
        {
            queryString.Add("timezone", parameters.TimeZone);
        }

        if (queryString.Count > 0)
        {
            url += "?" + queryString.ToString();
        }
        // We don't throw an exception but also we don't make an unnecessary call to the server as the
        // result would be an empty weather object anyway.
        else return new();

        return await GetWeatherAsync(url).ConfigureAwait(false);
    }

    private async Task<Weather> GetWeatherAsync(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        return JsonSerializer.Deserialize<Weather>(json) ?? new();
    }

    #endregion

    #region WeatherAlerts

    #endregion
}

#endif