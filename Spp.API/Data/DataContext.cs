using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Spp.API.Data.Entities;
using Spp.Data.Entities;

namespace Spp.API.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Fondo> Fondos { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TipoDocumento>().HasIndex(x => x.Description).IsUnique();
        }
    }
}
