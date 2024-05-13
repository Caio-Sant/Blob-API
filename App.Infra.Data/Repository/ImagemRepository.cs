using App.Domain.Entities;
using App.Infra.Data.Context;
using App.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repository;

public class ImagemRepository : IImagemRepository
{
    private readonly ImagemContext context;

    public ImagemRepository(ImagemContext context)
    {
        this.context = context;
    }

    public async Task<List<Arquivo>> GetArquivosAsync()
    {
        return await context.Arquivos.ToListAsync();
    }
}