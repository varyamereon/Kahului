#if IOS16_OR_GREATER || MACCATALYST16_0_OR_GREATER

using System;
using System.Collections.Generic;
using System.Text;

namespace Kahului.WeatherKit
{

    public Task<List<DataSet>> GetAvailableDataSets(double latitude, double longitude)
    {
        throw new NotImplementedException();
    }

    public Task<Weather> GetWeatherAsync(string language, double latitude, double longitude)
    {
        throw new NotImplementedException();
    }
}

#endif