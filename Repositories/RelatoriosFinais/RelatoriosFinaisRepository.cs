using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories.Interfaces;

namespace RotaLimpa.Api.Repositories
{
    public class RelatoriosFinaisRepository : IRelatoriosFinaisRepository
    {
        private readonly DataContext _context;

        public RelatoriosFinaisRepository(DataContext context)
        {
            _context = context;
        }

     
        public async Task<List<RelatorioFinal>> GetAllRelatoriosFinaisAsync()
        {
            List<RelatorioFinal> relatorioFinal = await _context.RelatoriosFinais.ToListAsync();
            return relatorioFinal;
        }

        public async Task<RelatorioFinal> GetRelatorioFinalByIdAsync(int id)
        {
            return await _context.RelatoriosFinais.FirstOrDefaultAsync(relatoriobusca => relatoriobusca.IdRelatorio == id);
        }
        public async Task CreateRelatorioFinalAsync(RelatorioFinal relatorioFinal)
        {
            await _context.AddAsync(relatorioFinal);
        }

        public async Task RemoveRelatorioFinal(RelatorioFinal relatorioFinal)
        {
            _context.RelatoriosFinais.Remove(relatorioFinal);
        }
    }
}
