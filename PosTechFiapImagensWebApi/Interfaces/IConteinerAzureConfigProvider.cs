using PosTechFiapImagensWebApi.Util.Azure;

namespace PosTechFiapImagensWebApi.Interfaces;

public interface IConteinerAzureConfigProvider
{
    ConteinerAzureConfig GetConteinerAzureConfig();
}