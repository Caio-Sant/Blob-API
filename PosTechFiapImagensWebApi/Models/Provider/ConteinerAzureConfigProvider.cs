using Microsoft.Extensions.Options;
using PosTechFiapImagensWebApi.Interfaces;
using PosTechFiapImagensWebApi.Util.Azure;

namespace PosTechFiapImagensWebApi.Models.Provider;

public class ConteinerAzureConfigProvider : IConteinerAzureConfigProvider
{
    private readonly IOptions<ConteinerAzureConfig> _conteinerAzureConfig;

    public ConteinerAzureConfigProvider(IOptions<ConteinerAzureConfig> conteinerAzureConfig)
    {
        _conteinerAzureConfig = conteinerAzureConfig;
    }

    public ConteinerAzureConfig GetConteinerAzureConfig()
    {
        return _conteinerAzureConfig.Value;
    }
}