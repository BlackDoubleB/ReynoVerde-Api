using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiReynoVerde.Entidades;

namespace WebApiReynoVerde
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Producto>(entity => {
                entity.ToTable("Producto");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
                entity.Property(p => p.ProductoNombre).IsRequired().HasMaxLength(100);
                entity.Property(p => p.ImagenUrl).IsRequired();
                entity.Property(p => p.Precio).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(p => p.FechaRegistro).IsRequired().HasDefaultValueSql("GETDATE()");
                entity.HasOne(p => p.Categoria)
                      .WithMany(c => c.Productos)
                      .HasForeignKey(p => p.CategoriaId);
                
            });

            modelBuilder.Entity<Categoria>(entity => {
                entity.ToTable("Categoria");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();
                entity.Property(c => c.NombreCategoria).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Stock>(entity => {
                entity.ToTable("Stock");
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Id).ValueGeneratedOnAdd();
                entity.Property(s => s.Cantidad).IsRequired();
                entity.Property(s => s.FechaRegistro).IsRequired().HasDefaultValueSql("GETDATE()");
                entity.HasOne(s => s.Producto)
                      .WithOne(p => p.Stock)
                      .HasForeignKey<Stock>(s => s.ProductoId);
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("Venta");
                entity.HasKey(v => v.Id);
                entity.Property(v => v.Id).ValueGeneratedOnAdd();
                entity.Property(v => v.Metodo).IsRequired().HasMaxLength(50);
                entity.Property(v => v.FechaRegistro).IsRequired().HasDefaultValueSql("GETDATE()");
                entity.Property(v => v.Total).IsRequired().HasColumnType("decimal(18,2)");
            });
            modelBuilder.Entity<DetalleVentaProducto>(entity =>
            {
                entity.ToTable("DetalleVentaProducto");
                entity.HasKey(d => d.Id);
                entity.Property(d => d.Cantidad).IsRequired();
                entity.HasOne(d => d.Producto)
                      .WithMany(p => p.DetallesVentaProductoP)
                      .HasForeignKey(d => d.ProductoId);
                entity.HasOne(d => d.Venta)
                      .WithMany(v => v.DetallesVentaProductoV)
                      .HasForeignKey(d => d.VentaId);
            });

        }

        //Añadiendo DbSet para Mapear las entidades a tablas en bd
        public DbSet<Categoria> Categoria { get; set; }  
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<DetalleVentaProducto> DetalleVentaProducto { get; set; }
        public DbSet<Venta> Venta { get; set; }

    }
}
