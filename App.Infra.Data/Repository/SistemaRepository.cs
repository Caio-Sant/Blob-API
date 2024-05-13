using App.Infra.Data.Context;
using App.Infra.Data.Interfaces;

namespace App.Infra.Data.Repository;

public class SistemaRepository : ISistemaRepository
{
    private readonly ImagemContext _context;

    public SistemaRepository(ImagemContext context)
    {
        _context = context;
    }

    public bool VerificarChaveExiste(string chave)
    {
        return _context.Sistemas.Any(c => c.Chave.Equals(chave));
    }
}