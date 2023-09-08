using Microsoft.EntityFrameworkCore;
using RotaLimpa.api.Models;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

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

    }
}