using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Repositories.Interfaces
{
    public interface IRelatoriosFinaisRepository
    {
        public Task<List<RelatorioFinal>> GetAllRelatoriosFinaisAsync();
        public Task<RelatorioFinal> GetRelatorioFinalByIdAsync(int id);
        public Task CreateRelatorioFinalAsync(RelatorioFinal relatorioFinal);
        public Task RemoveRelatorioFinal( RelatorioFinal relatorioFinal);
        
    }
}
