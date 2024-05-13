using App.Domain.Entities;
using App.Infra.Data.Interfaces;
using App.Infra.Data.Repository;

namespace App.Application.Services;

public class ImagemService
{
    private readonly IImagemContextFactory _contextFactory;

    public ImagemService(IImagemContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<Arquivo>> GetArquivosAsync()
    {
        using (var context = _contextFactory.Create())
        {
            var repository = new ImagemRepository(context);
            return await repository.GetArquivosAsync();
        }
    }
}