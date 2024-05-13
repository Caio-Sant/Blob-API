using PosTechFiapImagensWebApi.Models.Response;

namespace PosTechFiapImagensWebApi.Interfaces;

public interface IAzureStorageBlobService
{
    Task<int> RecuperarImagensDeletadas(string nomeImagem);
    Task<int> DeletarImagemPorNome(string nomeIMG);
    List<ImagemResponseViewModel> PesquisarTodasImagensDeletadas();
    Task<ImagemResponseViewModel> UploadImagemAsync(BinaryData binaryData, string nome);
    List<ImagemResponseViewModel> PesquisarTodasImagens();
    Uri PesquisarUriArquivoPorNome(string nomeArquivo);
}