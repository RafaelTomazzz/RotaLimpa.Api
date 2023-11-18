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
    public class TrajetosRepository : ITrajetosRepository
    {
        private readonly DataContext _context;
        public TrajetosRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trajeto>> GetAllTrajetosAsync()
        {
            IEnumerable<Trajeto> trajeto = await _context.Trajetos.ToListAsync();
            return trajeto;
        }

        public async Task<Trajeto> GetTrajetoByIdAsync(int id)
        {
            return await _context.Trajetos.FirstOrDefaultAsync(o => o.Id == id);
        }
        
        public async Task CreateTrajetoAsync(Trajeto trajeto)
        {
            await _context.AddAsync(trajeto);
        }

        public async Task RemoveTrajeto(Trajeto trajeto)
        {
            _context.Trajetos.Remove(trajeto);
        }

    }
}
