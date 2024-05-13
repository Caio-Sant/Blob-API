using Microsoft.IdentityModel.Tokens;
using PosTechFiapImagensWebApi.Interfaces;
using System.Security.Cryptography;

#nullable disable

namespace PosTechFiapImagensWebApi.Factory;

public class RsaSecurityKeyFactory : IRsaSecurityKeyFactory
{
    private readonly IConfiguration _configuration;

    public RsaSecurityKeyFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public RsaSecurityKey Create()
    {
        RSA rsa = RSA.Create();
        rsa.ImportRSAPrivateKey(
            source: Convert.FromBase64String(_configuration["Jwt:Asymmetric:PrivateKey"]),
            bytesRead: out int _);

        return new RsaSecurityKey(rsa);
    }
}