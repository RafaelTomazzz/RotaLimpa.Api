using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Models.Enum;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<CEP> CEPs { get; set; }
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
        public DbSet<HisLoginC> HisLoginCs { get; set; }
        public DbSet<HisLoginM> HisLoginMs { get; set; }
        public DbSet<RelatorioFinal> RelatoriosFinais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CEP>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<CEP>()
                .HasMany(c => c.Ruas)
                .WithOne(r => r.CEP)
                .HasForeignKey(r => r.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Kilometragem>()
                .HasKey(k => k.IdVeiculo);

            modelBuilder.Entity<Kilometragem>()
                .Property(k => k.IdVeiculo)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Kilometragem>()
                .HasOne(k => k.Frota)
                .WithOne(f => f.Kilometragem)
                .HasForeignKey<Kilometragem>(k => k.IdVeiculo)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rua>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Rua>()
                .HasOne(r => r.CEP)
                .WithMany(cep => cep.Ruas)
                .HasForeignKey(r => r.IdCep)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rua>()
                .HasOne(r => r.Rota)
                .WithMany(rota => rota.Ruas)
                .HasForeignKey(r => r.IdRota)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Setor>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Setor>()
                .HasOne(s => s.Colaborador)
                .WithMany(c => c.Setores)
                .HasForeignKey(s => s.IdColaborador)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Setor>()
                .HasOne(s => s.Empresa)
                .WithMany(e => e.Setores)
                .HasForeignKey(s => s.IdEmpresa)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Setor>()
                .HasMany(s => s.Rotas)
                .WithOne(r => r.Setor)
                .HasForeignKey(r => r.IdSetor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Setor>()
                .HasMany(s => s.RelatoriosFinais)
                .WithOne()
                .HasForeignKey(rf => rf.IdSetor)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SetorVeiculo>()
                .HasKey(sv => new { sv.IdSetor, sv.IdFrota });

            modelBuilder.Entity<SetorVeiculo>()
                .HasOne(sv => sv.Setor)
                .WithMany(s => s.SetorVeiculos)
                .HasForeignKey(sv => sv.IdSetor)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SetorVeiculo>()
                .HasOne(sv => sv.Frota)
                .WithMany(f => f.SetorVeiculos)
                .HasForeignKey(sv => sv.IdFrota)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Trajeto>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Trajeto>()
                .HasOne(t => t.Motorista)
                .WithMany(m => m.Trajetos)
                .HasForeignKey(t => t.IdMotorista)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Trajeto>()
                .HasOne(t => t.Rota)
                .WithMany(r => r.Trajetos)
                .HasForeignKey(t => t.IdRota)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Trajeto>()
                .HasOne(t => t.Frota)
                .WithMany(f => f.Trajetos)
                .HasForeignKey(t => t.IdFrota)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Trajeto>()
                .HasOne(t => t.Periodo)
                .WithMany(p => p.Trajetos)
                .HasForeignKey(t => t.IdPeriodo)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RelatorioFinal>()
                .HasOne(r => r.Setor)
                .WithMany(s => s.RelatoriosFinais)
                .HasForeignKey(r => r.IdSetor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RelatorioFinal>()
                .HasOne(r => r.Trajeto)
                .WithMany(o => o.RelatoriosFinais)
                .HasForeignKey(r => r.IdTrajeto)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rota>()
                .HasOne(r => r.Colaborador)
                .WithMany(c => c.Rotas)
                .HasForeignKey(r => r.IdColaborador)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rota>()
                .HasOne(r => r.Setor)
                .WithMany(s => s.Rotas)
                .HasForeignKey(r => r.IdSetor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HisLoginC>()
                .HasOne(h => h.Colaborador)
                .WithMany(c => c.HisLoginCs)
                .HasForeignKey(h => h.IdColaborador)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HisLoginM>()
                .HasOne(h => h.Motorista)
                .WithMany(m => m.HisLoginMs)
                .HasForeignKey(h => h.IdMotorista)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ocorrencia>()
                .HasOne(o => o.Trajeto)
                .WithMany(t => t.Ocorrencias)
                .HasForeignKey(o => o.IdTrajeto)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ocorrencia>()
                .HasOne(o => o.CEP)
                .WithMany()
                .HasForeignKey(o => o.IdCep)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Colaborador>()
                .HasOne(s => s.Empresa)
                .WithMany(e => e.Colaboradores)
                .HasForeignKey(s => s.IdEmpresa)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
