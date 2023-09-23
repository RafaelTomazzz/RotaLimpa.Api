using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.api.Models.Enum;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colaborador>()
                 .HasOne(c => c.Empresas)
                 .WithMany()
                 .HasForeignKey(c => c.Empresa_Id)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Setor>()
                .HasOne(s => s.Empresa)
                .WithMany()
                .HasForeignKey( s => s.Id_Empresa);
        
            modelBuilder.Entity<Setor>()
                .HasOne(s => s.Colaborador)
                .WithMany(s => s.Setores)
                .HasForeignKey(s => s.Id_Colaborador);

            modelBuilder.Entity<Rota>()
                .HasOne(r => r.Colaborador)
                .WithMany(r => r.Rotas)
                .HasForeignKey(r => r.Id_Colaborador);

            modelBuilder.Entity<Rota>()
                .HasOne(r => r.Periodo)
                .WithMany(r => r.Rotas)
                .HasForeignKey(r => r.Id_Periodo);

            modelBuilder.Entity<Rota>()
                .HasOne(r => r.Setor)
                .WithMany()
                .HasForeignKey(r => r.Id_Setor);

        }
    }
}
