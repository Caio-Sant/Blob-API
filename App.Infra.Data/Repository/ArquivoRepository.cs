using App.Domain.Entities;
using App.Infra.Data.Context;
using App.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repository;

public class ArquivoRepository : IArquivoRepository
{
    private readonly ImagemContext _context;

    public ArquivoRepository(ImagemContext context)
    {
        _context = context;
    }

    public async Task<List<Arquivo>> GetArquivoAsync()
    {
        return await _context.Arquivos.ToListAsync();
    }

    public async Task InsertArquivoAsync(Arquivo arquivo)
    {
        await _context.Arquivos.AddAsync(arquivo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateArquivoAsync(Arquivo arquivo)
    {
        _context.Arquivos.Update(arquivo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteArquivoAsync(int arquivoId)
    {
        var arquivo = await _context.Arquivos.FindAsync(arquivoId);
        if (arquivo != null)
        {
            _context.Arquivos.Remove(arquivo);
            await _context.SaveChangesAsync();
        }
    }
}