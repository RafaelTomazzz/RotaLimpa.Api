using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories.Interfaces;

namespace RotaLimpa.Api.Repositories
{
    public class PeriodosRepository : IPeriodosRepository
    {
        private readonly DataContext _context;

        public PeriodosRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Periodo>> GetAllPeriodosAsync()
        {
            IEnumerable<Periodo> periodo = await _context.Periodos.ToListAsync();
            return periodo;
        }

        public async Task<Periodo> GetPeriodoByIdAsync(int id)
        {
            return await _context.Periodos.FirstOrDefaultAsync(perioBusca => perioBusca.Id == id);
            
        }
        public async Task CreatePeriodoAsync(Periodo periodo)
        {
            await _context.AddAsync(periodo);
        }
        public async Task RemovePeriodo(Periodo periodo)
        {
            _context.Periodos.Remove(periodo);
        }
    }

    
}
