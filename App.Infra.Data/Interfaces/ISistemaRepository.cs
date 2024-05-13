namespace App.Infra.Data.Interfaces;

public interface ISistemaRepository
{
    bool VerificarChaveExiste(string chave);
}