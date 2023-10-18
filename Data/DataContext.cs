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
        public DbSet<Kilometragem> Kilometragens { get; set; }
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
                 .HasOne(c => c.Empresa)
                 .WithMany(e => e.Colaboradores)
                 .HasForeignKey(c => c.EmpresaId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Setor>()
                .HasOne(s => s.Empresa)
                .WithMany(e => e.Setores)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Setor>()
                .HasOne(s => s.Colaborador)
                .WithMany(s => s.Setores)
                .HasForeignKey(s => s.ColaboradorId);

            modelBuilder.Entity<Rota>()
                .HasOne(r => r.Colaborador)
                .WithMany(r => r.Rotas)
                .HasForeignKey(r => r.ColaboradorId);

            modelBuilder.Entity<Rota>()
                .HasOne(r => r.Periodo)
                .WithMany(r => r.Rotas)
                .HasForeignKey(r => r.IdPeriodo);

            modelBuilder.Entity<Rota>()
                 .HasOne(r => r.Setor)
                 .WithMany(s => s.Rotas)
                 .HasForeignKey(r => r.SetorId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rua>()
                .HasOne(r => r.CEP)
                .WithMany(c => c.Ruas)
                .HasForeignKey(r => r.Cep);

            modelBuilder.Entity<Rua>()
                .HasOne(r => r.Rota)
                .WithMany(r => r.Ruas)
                .HasForeignKey(r => r.RotaId);

            modelBuilder.Entity<SetorVeiculo>()
                .HasOne(s => s.Setor)
                .WithMany()
                .HasForeignKey(s => s.IdSetor);

            /*modelBuilder.Entity<SetorVeiculo>()
                .HasOne(s => s.Frota)
                .WithMany()
                .HasPrincipalKey(s => new {s.Id_Setor, s.Id_Frota})
                .HasForeignKey(s => s.Id_Frota);*/

            modelBuilder.Entity<Ocorrencia>()
                .HasOne(c => c.Trajeto)
                .WithMany()
                .HasForeignKey(c => c.IdTrajeto);

            modelBuilder.Entity<Trajeto>()
                .HasOne(t => t.Motorista)
                .WithMany()
                .HasForeignKey(t => t.IdMotorista);

            modelBuilder.Entity<Trajeto>()
                .HasOne(t => t.Rota)
                .WithMany()
                .HasForeignKey(t => t.IdRota);

            modelBuilder.Entity<Trajeto>()
                .HasOne(t => t.Frota)
                .WithMany()
                .HasForeignKey(t => t.Id);
        }
    }
}