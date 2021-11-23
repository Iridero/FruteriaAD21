using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FruteriaAD21.Models
{
    public partial class fruteriashopContext : DbContext
    {
        public fruteriashopContext()
        {
        }

        public fruteriashopContext(DbContextOptions<fruteriashopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categorias");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.Nombre, "NombreGrupo");

                entity.Property(e => e.Id).HasColumnType("int(10)");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("productos");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.IdCategoria, "GruposProductos");

                entity.HasIndex(e => e.Id, "IdProducto");

                entity.Property(e => e.Id).HasColumnType("int(10)");

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.IdCategoria).HasColumnType("int(10)");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Precio).HasPrecision(19, 4);

                entity.Property(e => e.UnidadMedida).HasMaxLength(45);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("fk_categorias");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
