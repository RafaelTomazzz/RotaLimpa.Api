using Microsoft.EntityFrameworkCore;
using RotaLimpa.api.Models;
using RotaLimpa.Api.Models;

namespace RotaLimpa.api.Data 
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<Funcionario> Funcionarios {get; set;}

        public DbSet<Empresa> Empresas {get; set;}
    }
}