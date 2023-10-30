using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using nuevapicobro.Domain.Entities;

namespace nuevapicobro
{
    public partial  class DbPayUsContext : DbContext
    {
        public DbPayUsContext()
        {
        }

        public DbPayUsContext(DbContextOptions<DbPayUsContext> options)
            : base(options)
        {
        }

            public virtual DbSet<Carrito> Carritos { get; set; }

    public virtual DbSet<CarritoProducto> CarritoProductos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VentaDetalle> VentaDetalles { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Daniel\\DANIEL;Database=DB_PayUs;User=sa;Password=dcd238e3;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carritos__3214EC07147985A0");

            entity.Property(e => e.UsuarioId)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Carritos__Usuari__440B1D61");
        });

        modelBuilder.Entity<CarritoProducto>(entity =>
        {
            entity.HasKey(e => new { e.CarritoId, e.ProductoId }).HasName("PK__CarritoP__5DCE5281A5C244EF");

            entity.HasOne(d => d.Carrito).WithMany(p => p.CarritoProductos)
                .HasForeignKey(d => d.CarritoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarritoPr__Carri__5070F446");

            entity.HasOne(d => d.Producto).WithMany(p => p.CarritoProductos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarritoPr__Produ__5165187F");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC0723494F4C");

            entity.HasIndex(e => e.Nombre, "UQ__Producto__75E3EFCF33EC07D5").IsUnique();

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.NumeroTelefono).HasName("PK__Usuarios__0DC3DBF4C9B33CB1");

            entity.Property(e => e.NumeroTelefono)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VentaDetalle>(entity =>
        {
            entity.HasKey(e => new { e.VentaId, e.ProductoId }).HasName("PK__VentaDet__71025A46D9757F3A");

            entity.HasOne(d => d.Producto).WithMany(p => p.VentaDetalles)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VentaDeta__Produ__4D94879B");

            entity.HasOne(d => d.Venta).WithMany(p => p.VentaDetalles)
                .HasForeignKey(d => d.VentaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VentaDeta__Venta__4CA06362");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Venta__3214EC0726C9DCBF");

            entity.Property(e => e.MontoTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UsuarioId)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Ventas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Venta__UsuarioId__49C3F6B7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        
    }
}