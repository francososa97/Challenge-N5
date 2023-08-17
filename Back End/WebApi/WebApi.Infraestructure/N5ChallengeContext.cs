using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApi.Infraestructure.Domain;

namespace WebApi.Infraestructure;

public partial class N5ChallengeContext : DbContext
{
    public N5ChallengeContext()
    {
    }

    public N5ChallengeContext(DbContextOptions<N5ChallengeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<TipoPermiso> TipoPermisos { get; set; }

    //To do pasar esto a un secret
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-OGUUOAT\\SQLEXPRESS;Database=N5 Challenge; Trusted_Connection=true; TrustServerCertificate=True;");

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
