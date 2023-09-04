using Microsoft.EntityFrameworkCore;
using RotaLimpa.api.Models;

namespace RotaLimpa.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Funcionario> Funcionarios { get; set; }

        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>()
                .HasOne(f => f.Empresa)
                .WithMany();
        }
    }
}
