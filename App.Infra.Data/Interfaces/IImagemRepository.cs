using App.Domain.Entities;

namespace App.Infra.Data.Interfaces;

public interface IImagemRepository
{
    Task<List<Arquivo>> GetArquivosAsync();
}