using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories.Interfaces;

namespace RotaLimpa.Api.Repositories
{
    public class RuasRepository : IRuasRepository
    {
        private readonly DataContext _context;
        public RuasRepository(DataContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<Rua>> GetAllRuasAsync()
        {
            IEnumerable<Rua> rua = await _context.Ruas.ToListAsync();
            return rua;
        }
        public async Task<Rua> GetRuaByIdAsync(int id)
        {
            return await _context.Ruas.FirstOrDefaultAsync(ruaBusca => ruaBusca.Id == id);
        }
        public async Task CreateRuaAsync(Rua rua)
        {
            await _context.AddAsync(rua);
        }
        public async Task RemoveRua(Rua rua)
        {
            _context.Ruas.Remove(rua);
        }

        public async Task<IEnumerable<Rua>> GetAllRuaWhereRotaAsync(int idrota)
        {
            IEnumerable<Rua> ruas = await _context.Ruas.Where(o => o.IdRota == idrota).ToListAsync();
            return ruas;
        }


    }
}
