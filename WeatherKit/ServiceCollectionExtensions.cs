using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Kahului.WeatherKit;
public static class ServiceCollectionExtensions
{
    public static void AddWeatherKit(this IServiceCollection services, string privateKey, string keyId, string teamId, string serviceId)
    {
#if !IOS16_0_OR_GREATER && !MACCATALYST16_0_OR_GREATER
        services.AddHttpClient<IWeatherKit, WeatherKit>(client =>
        {
            var iat = (int)(DateTime.UtcNow - DateTime.UnixEpoch).TotalSeconds;
            var exp = iat + (int)TimeSpan.FromDays(30).TotalSeconds;

            var privKeyBytes = Convert.FromBase64String(privateKey);
            var privKey = ECDsa.Create();
            privKey.ImportPkcs8PrivateKey(privKeyBytes, out var privBytesRead);
            var securityKey = new ECDsaSecurityKey(privKey);

            var header = new JwtHeader(new SigningCredentials(securityKey, SecurityAlgorithms.EcdsaSha256))
            {
                { JwtHeaderParameterNames.Kid, keyId },
                { "id", $"{teamId}.{serviceId}" }
            };

            var payload = new JwtPayload(new[]
            {
                new Claim(JwtRegisteredClaimNames.Iss, teamId),
                new Claim(JwtRegisteredClaimNames.Iat, iat.ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, exp.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, serviceId)
            });

            var handler = new JwtSecurityTokenHandler();

            var token = new JwtSecurityToken(header, payload);
            var raw = handler.WriteToken(token);

            client.DefaultRequestHeaders.Authorization=new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", raw);
            client.BaseAddress = new Uri("https://weatherkit.apple.com/api/v1/");
        });
#endif
    }
}
