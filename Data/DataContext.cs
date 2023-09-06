using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Colaboradores> Colaboradores {get; set;}
        public DbSet<Empresas> Empresas {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colaboradores>()
                .HasOne(c => c.Empresas)
                .WithMany();
        }
    }
}
