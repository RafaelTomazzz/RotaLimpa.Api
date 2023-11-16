using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories.Interfaces;

namespace RotaLimpa.Api.Repositories
{
    public class RotasRepository : IRotasRepository
    {
        private readonly DataContext _context;

        public RotasRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Rota>> GetAllRotasAsync()
        {
            IEnumerable<Rota> rota = await _context.Rotas.ToListAsync();
            return rota;
        }

        public async Task<Rota> GetRotaByIdAsync(int id)
        {
            return await _context.Rotas.FirstOrDefaultAsync(relatoriobusca => relatoriobusca.Id == id);
        }
        public async Task CreateRotaAsync(Rota rota)
        {
            await _context.AddAsync(rota);
        }

        public async Task RemoveRota(Rota rota)
        {
            _context.Rotas.Remove(rota);
            
        }
    }
}
