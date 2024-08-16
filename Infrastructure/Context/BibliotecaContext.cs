using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public partial class BibliotecaContext : DbContext
{
    public BibliotecaContext()
    {
    }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
        this.ChangeTracker.LazyLoadingEnabled = false;
    }

    public virtual DbSet<Auditorium> Auditoria { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<CodigoOtp> CodigoOtps { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<ListaNegra> ListaNegras { get; set; }

    public virtual DbSet<Notificacion> Notificacions { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Biblioteca;User Id=sa;Password=sqlserver;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auditorium>(entity =>
        {
            entity.HasKey(e => e.AuditoriaId).HasName("PK__Auditori__095694E394DA6CCE");

            entity.Property(e => e.AuditoriaId).HasColumnName("AuditoriaID");
            entity.Property(e => e.Accion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Detalles).HasColumnType("text");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Auditoria)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Auditoria__Usuar__4CA06362");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategoriaId);

            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<CodigoOtp>(entity =>
        {
            entity.ToTable("CodigoOTP");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CodigoOtp1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CodigoOTP");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaExpiracion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.CodigoOtps)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CodigoOTP_Usuario");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.LibroId).HasName("PK__Libro__35A1EC8D0B876693");

            entity.ToTable("Libro");

            entity.Property(e => e.LibroId).HasColumnName("LibroID");
            entity.Property(e => e.Autor)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.CodigoBarras).HasMaxLength(100);
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ValorReferencial).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Libros)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Libro_Categoria");
        });

        modelBuilder.Entity<ListaNegra>(entity =>
        {
            entity.HasKey(e => e.ListaNegraId).HasName("PK__ListaNeg__99DC31216BBF97FE");

            entity.ToTable("ListaNegra");

            entity.HasIndex(e => e.UsuarioId, "UQ__ListaNeg__2B3DE7990AFB674E").IsUnique();

            entity.Property(e => e.ListaNegraId).HasColumnName("ListaNegraID");
            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            entity.Property(e => e.Motivo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithOne(p => p.ListaNegra)
                .HasForeignKey<ListaNegra>(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ListaNegr__Usuar__49C3F6B7");
        });

        modelBuilder.Entity<Notificacion>(entity =>
        {
            entity.HasKey(e => e.NotificacionId).HasName("PK__Notifica__BCC120C499B7D22B");

            entity.ToTable("Notificacion");

            entity.Property(e => e.NotificacionId).HasColumnName("NotificacionID");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Mensaje).HasColumnType("text");
            entity.Property(e => e.Tipo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Notificacions)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificac__Usuar__4F7CD00D");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.PrestamoId).HasName("PK__Prestamo__AA58A080DF847C72");

            entity.ToTable("Prestamo");

            entity.Property(e => e.PrestamoId).HasColumnName("PrestamoID");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaDevolucion).HasColumnType("datetime");
            entity.Property(e => e.FechaPrestamo).HasColumnType("datetime");
            entity.Property(e => e.FechaSolicitud).HasColumnType("datetime");
            entity.Property(e => e.LibroId).HasColumnName("LibroID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Libro).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.LibroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prestamo_Libro");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prestamo__Usuari__44FF419A");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE798DA5B5A69");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.NumeroDocumento, "UQ__Usuario__A4202588F43FACFB").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534E3ABBCDF").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Ubigeo)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
