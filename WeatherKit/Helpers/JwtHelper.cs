using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Kahului.WeatherKit.Helpers;
/// <summary>
/// Helper methods for JWT.
/// </summary>
internal static class JwtHelper
{
    /// <summary>
    /// Generates the JWT signed by the provided key.
    /// </summary>
    /// <param name="privateKey">The private key to sign with.</param>
    /// <param name="keyId">The identifier of the key.</param>
    /// <param name="teamId">The Apple team identifier.</param>
    /// <param name="serviceId">The Apple service identifier.</param>
    /// <param name="tokenValidity">The validity of the outputted token in minutes.</param>
    /// <returns></returns>
    internal static string GenerateToken(string privateKey, string keyId, string teamId, string serviceId, int tokenValidity)
    {
        var iat = (int)(DateTime.UtcNow - DateTime.UnixEpoch).TotalSeconds;
        var exp = iat + (int)TimeSpan.FromMinutes(tokenValidity).TotalSeconds;

        var privKeyBytes = Convert.FromBase64String(privateKey);
        var privKey = ECDsa.Create();
        privKey.ImportPkcs8PrivateKey(privKeyBytes, out _);
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
        return handler.WriteToken(token);
    }
}
