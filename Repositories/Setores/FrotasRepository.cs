using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories.Interfaces;

namespace RotaLimpa.Api.Repositories
{
    public class SetoresRepository : ISetoresRepository
    {
        private readonly DataContext _context;
        public SetoresRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Setor>> GetAllSetoresAsync()
        {
            IEnumerable<Setor> setor = await _context.Setores.ToListAsync();
            return setor;
        }

        public async Task<Setor> GetSetorByIdAsync(int id)
        {
            return await _context.Setores.FirstOrDefaultAsync(f => f.Id == id);
        }
        
        public async Task CreateSetorAsync(Setor setor)
        {
            await _context.AddAsync(setor);
        }

        public async Task RemoveSetor(Setor setor)
        {
            _context.Setores.Remove(setor);
        }

    }
}
