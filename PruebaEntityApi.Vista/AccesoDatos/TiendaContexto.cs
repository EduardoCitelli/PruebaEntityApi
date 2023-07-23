namespace PruebaEntityApi.Vista.AccesoDatos
{
    using Microsoft.EntityFrameworkCore;
    using PruebaEntityApi.Vista.Modelos;

    public class TiendaContexto : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public TiendaContexto(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(@"Server=.\MSI;Database=MyDb;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categoria>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Producto>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Producto>()
                        .Property(x => x.Precio)
                        .HasPrecision(16, 2);

            modelBuilder.Entity<Producto>()
                        .HasOne(x => x.Categoria)
                        .WithMany(x => x.Productos)
                        .HasForeignKey(x => x.CategoriaId);
        }
    }
}
