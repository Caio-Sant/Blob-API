using App.Infra.Data.Context;

namespace App.Infra.Data.Interfaces;

public interface IImagemContextFactory
{
    ImagemContext Create();
}