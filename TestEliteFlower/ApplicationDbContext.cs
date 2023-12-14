using Microsoft.EntityFrameworkCore;
using TestEliteFlower.Domain.Entities;

namespace TestEliteFlower
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>()
                .Property(a => a.Codigo)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Fabricante>()
                .HasKey(f => f.Codigo);

            base.OnModelCreating(modelBuilder);
        }
    }
}