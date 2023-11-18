using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Services
{
    public interface IRelatoriosFinaisService
    {
        public Task<IEnumerable<RelatorioFinal>> GetAllRelatoriosFinaisAsync();
        public Task<RelatorioFinal> GetRelatorioFinalByIdAsync(int id);
        public Task<RelatorioFinal> CreateRelatorioFinalAsync(RelatorioFinal relatorioFinal);
        public Task<RelatorioFinal> UpdateRelatorioFinalAsync(int id, RelatorioFinal relatorioFinal);
        public Task<RelatorioFinal> RemoveRelatorioFinal(int id, RelatorioFinal relatorioFinal);
    }
}
