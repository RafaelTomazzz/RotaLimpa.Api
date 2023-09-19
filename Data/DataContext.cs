using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.api.Models.Enuns;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<CEP> Ceps { get; set; }
        public DbSet<Frota> Frotas { get; set; }
        public DbSet<Kilometragem> Kilometragems { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<Rota> Rotas { get; set; }
        public DbSet<Rua> Ruas { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<SetorVeiculo> SetorVeiculos { get; set; }
        public DbSet<Trajeto> Trajetos { get; set; }
        public DbSet<TiposServico> TiposServico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colaborador>()
                 .HasOne(c => c.Empresas)
                 .WithMany()
                 .HasForeignKey(c => c.Empresa_Id)
                 .OnDelete(DeleteBehavior.NoAction);

            /*modelBuilder.Entity<Setor>()
                .HasOne(s => s.TipoServico/ s => s.Empresas)
                .WithMany(s => s.)*/
        }
    }
}
