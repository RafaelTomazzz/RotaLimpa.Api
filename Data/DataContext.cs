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
                 .HasOne(c => c.Empresa)
<<<<<<< HEAD
                 .WithMany()
                 .HasForeignKey(c => c.Empresa_Id)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Setor>()
                .HasOne(s => s.Empresa)
                .WithMany()
                .HasForeignKey( s => s.Id_Empresa);
                .HasKey
        
=======
                 .WithMany(e => e.Colaboradores)
                 .HasForeignKey(c => c.EmpresaId)
                 .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Setor>()
            //    .HasOne(s => s.Empresa)
            //    .WithMany()
            //    .HasForeignKey(s => s.Id_Empresa);

>>>>>>> origin/Rafael
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

<<<<<<< HEAD
            // modelBuilder.Entity<Rua>()
            //     .HasOne(r => r.CEP)
            //     .WithMany();

            modelBuilder.Entity<Trajeto>()
                .HasOne(s => s.Motorista)
                .WithMany()
                .HasForeignKey( s => s.Id_Motorista);

            modelBuilder.Entity<Trajeto>()
                .HasOne(s => s.Rota)
                .WithMany()
                .HasForeignKey( s => s.Id_Rota);

            modelBuilder.Entity<Trajeto>()
                .HasOne(s => s.Frota)
                .WithMany()
                .HasForeignKey( s => s.Id_Veiculo);

                -----------------------------------------------

            modelBuilder.Entity<SetorVeiculo>()
                .HasOne(s => s.Frota)
                .WithMany()
                .HasForeignKey( s => s.Id_Veiculo);
=======
            modelBuilder.Entity<Rua>()
                .HasOne(r => r.CEP)
                .WithMany(c => c.Ruas)
                .HasForeignKey(r => r.Cep);

            modelBuilder.Entity<Rua>()
                .HasOne(r => r.Rota)
                .WithMany(r => r.Ruas)
                .HasForeignKey(r => r.RotaId);
>>>>>>> origin/Rafael

            modelBuilder.Entity<SetorVeiculo>()
                .HasOne(s => s.Setor)
                .WithMany()
<<<<<<< HEAD
                .HasForeignKey( s => s.Id_Setor);

                ------------------------------------------------

            modelBuilder.Entity<Ocorrencia>()
                .HasOne(s => s.Trajeto)
                .WithMany()
                .HasForeignKey( s => s.Id_Trajeto);

            modelBuilder.Entity<Ocorrencia>()
                .HasOne(s => s.TiposOcorrencia)
                .WithMany()
                .HasForeignKey( s => s.Tipo_Ocorrencia);

                ------------------------------------------------

            modelBuilder.Entity<Kilometragem>()
                .HasOne(s => s.Frota)
                .WithMany()
                .HasForeignKey( s => s.Id_Veiculo);



=======
                .HasForeignKey(s => s.Id);

            /*modelBuilder.Entity<SetorVeiculo>()
                .HasOne(s => s.Frota)
                .WithMany()
                .HasPrincipalKey(s => new {s.Id_Setor, s.Id_Frota})
                .HasForeignKey(s => s.Id_Frota);*/
>>>>>>> origin/Rafael
        }
    }
}
