using App.Domain.Entities;

namespace App.Application.Interfaces;

public interface IImagemService
{
    Task<List<Arquivo>> GetArquivosAsync();
}