using Microsoft.Extensions.DependencyInjection;

namespace Kahului.WeatherKit;
/// <summary>
/// Extensions for initializing WeatherKit.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// The name of the <see cref="HttpClient"/> created by WeatherKit.
    /// </summary>
    public const string weatherKitClientName = "WeatherKitClient";

    /// <summary>
    /// Configures and adds an instance of <see cref="IWeatherKit"/> to your services.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="privateKey">The private key you received in the p8 file from Apple.</param>
    /// <param name="keyId">The 10 character identifier belonging to the key.</param>
    /// <param name="teamId">The 10 character identifier of your Apple developer team.</param>
    /// <param name="serviceId">The service identifier in the format com.example.name.</param>
    /// <param name="tokenValidity">The validity of the generated token in minutes.</param>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static void AddWeatherKit(this IServiceCollection services, string privateKey, string keyId, string teamId, string serviceId, int tokenValidity = 1440)
    {
#if !IOS16_0_OR_GREATER && !MACCATALYST16_0_OR_GREATER
        if (string.IsNullOrEmpty(privateKey) || string.IsNullOrEmpty(keyId) || string.IsNullOrEmpty(keyId) || string.IsNullOrEmpty(serviceId))
            throw new NullReferenceException("WeatherKit was initialized with a null value.");

        if (tokenValidity < 1)
            throw new ArgumentException("The token validitiy must be a positive number.");

        services.AddHttpClient<IWeatherKit, WeatherKit>(weatherKitClientName, client =>
        {
            var token = JwtHelper.GenerateToken(privateKey, keyId, teamId, serviceId, tokenValidity);

            client.DefaultRequestHeaders.Authorization = new("Bearer", token);
            client.BaseAddress = new Uri("https://weatherkit.apple.com/api/v1/");
        });
#endif
    }
}
