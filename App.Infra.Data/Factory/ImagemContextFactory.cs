using App.Infra.Data.Context;
using App.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.Infra.Data.Factory;

public class ImagemContextFactory : IImagemContextFactory
{
    private readonly IConfiguration _configuration;

    public ImagemContextFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public ImagemContext Create()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ImagemContext>();
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AzureBdContext"));

        return new ImagemContext(optionsBuilder.Options);
    }
}