using Microsoft.IdentityModel.Tokens;

namespace PosTechFiapImagensWebApi.Interfaces;

public interface IRsaSecurityKeyFactory
{
    RsaSecurityKey Create();
}