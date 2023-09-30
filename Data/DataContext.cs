<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
using RotaLimpa.api.Models;
=======
﻿using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.api.Models.Enum;
>>>>>>> origin/Rafael
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

<<<<<<< HEAD
        public DbSet<CEP> CEPs { get; set; }
        public DbSet<Colaboradores> Colaboradores { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Frotas> Frotas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Kilometragens> Kilometragens { get; set; }
        public DbSet<Motoristas> Motoristas { get; set; }
        public DbSet<Ocorrencias> Ocorrencias { get; set; }
        public DbSet<Periodos> Periodos { get; set; }
        public DbSet<Rotas> Rotas { get; set; }
        public DbSet<Ruas> Ruas { get; set; }
        public DbSet<Setores> Setores { get; set; }
        public DbSet<SetorVeiculos> SetorVeiculos { get; set; }
        public DbSet<Trajetos> Trajetos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Funcionario>()
                .HasOne(f => f.Empresa)
                .WithMany();*/
            modelBuilder.Entity<CEP>().HasKey(e => e.Id_Cep);
            modelBuilder.Entity<Colaboradores>().HasKey(e => e.id);
            modelBuilder.Entity<Empresa>().HasKey(e => e.Id);
            modelBuilder.Entity<Empresas>().HasKey(e => e.Id_Empresa);
            modelBuilder.Entity<Frotas>().HasKey(e => e.Id_Veiculo);
            modelBuilder.Entity<Funcionario>().HasKey(e => e.Id_Funcionario);
            modelBuilder.Entity<Kilometragens>().HasKey(e => e.Id_Veiculo);
            modelBuilder.Entity<Motoristas>().HasKey(e => e.Id_Motorista);
            modelBuilder.Entity<Ocorrencias>().HasKey(e => e.Id_Ocorrencia);
            modelBuilder.Entity<Periodos>().HasKey(e => e.Id_Periodo);
            modelBuilder.Entity<Rotas>().HasKey(e => e.Id_Rota);
            modelBuilder.Entity<Ruas>().HasKey(e => e.Id_Ruas);
            modelBuilder.Entity<Setores>().HasKey(e => e.Id_Setor);
            modelBuilder.Entity<SetorVeiculos>().HasKey(e => new { e.Id_Setor, e.Id_Veiculo });
            modelBuilder.Entity<Trajetos>().HasKey(e => e.Id_Trajeto);

            modelBuilder.Entity<CEP>().HasIndex(e => e.Cep).IsUnique();
            modelBuilder.Entity<Colaboradores>().HasIndex(e => e.Nome).IsUnique();

        }

=======
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

            // modelBuilder.Entity<Rua>()
            //     .HasOne(r => r.CEP)
            //     .WithMany();

            modelBuilder.Entity<Rua>()
                .HasOne(r => r.Rota)
                .WithMany()
                .HasForeignKey(r => r.Id_Rota);

            modelBuilder.Entity<SetorVeiculo>()
                .HasOne(s => s.Setor)
                .WithMany()
                .HasForeignKey(s => s.Id_Setor);

            /*modelBuilder.Entity<SetorVeiculo>()
                .HasOne(s => s.Frota)
                .WithMany()
                .HasPrincipalKey(s => new {s.Id_Setor, s.Id_Frota})
                .HasForeignKey(s => s.Id_Frota);*/

            

        }
>>>>>>> origin/Rafael
    }
}