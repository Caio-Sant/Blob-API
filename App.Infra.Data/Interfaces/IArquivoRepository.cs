using App.Domain.Entities;

namespace App.Infra.Data.Interfaces;

public interface IArquivoRepository
{
    Task<List<Arquivo>> GetArquivoAsync();
    Task InsertArquivoAsync(Arquivo arquivo);
    Task UpdateArquivoAsync(Arquivo arquivo);
    Task DeleteArquivoAsync(int arquivoId);
}