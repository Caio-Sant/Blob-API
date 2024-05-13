using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Context;

public partial class ImagemContext : DbContext
{
    public ImagemContext(DbContextOptions<ImagemContext> options) : base(options)
    {
    }

    public virtual DbSet<Arquivo> Arquivos { get; set; }
    public virtual DbSet<Sistema> Sistemas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Arquivo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Arquivo__3214EC07AF62A4B5");
            entity.ToTable("Arquivo");
            entity.Property(e => e.NomeArquivo).HasMaxLength(50);
        });

        modelBuilder.Entity<Sistema>(entity =>
        {
            entity.HasKey(e => e.SistemaId).HasName("PK__Sistema__4C36BB8622AE2DCF");
            entity.ToTable("Sistema");
            entity.Property(e => e.SistemaId).ValueGeneratedNever();
            entity.Property(e => e.Chave).HasMaxLength(50);
            entity.Property(e => e.Descricao).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}