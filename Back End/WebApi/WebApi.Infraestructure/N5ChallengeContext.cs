using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Infraestructure.Domain;

namespace WebApi.Infraestructure;

public partial class N5ChallengeContext : DbContext
{
    private string ConnectionString;
    public N5ChallengeContext()
    {
        ConnectionString = "Server=DESKTOP-OGUUOAT\\SQLEXPRESS;Database=N5 Challenge; Trusted_Connection=true; TrustServerCertificate=True;";
    }
    public N5ChallengeContext(DbContextOptions<N5ChallengeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<TipoPermiso> TipoPermisos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.Property(e => e.ApellidoEmpleado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaPermiso).HasColumnType("date");
            entity.Property(e => e.NombreEmpleado)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoPermiso>(entity =>
        {
            entity.Property(e => e.Descripcion).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
