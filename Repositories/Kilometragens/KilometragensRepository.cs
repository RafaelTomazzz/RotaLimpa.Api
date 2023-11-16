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
    public class KilometragensRepository : IKilometragensRepository
    {
        private readonly DataContext _context;
        public KilometragensRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Kilometragem>> GetAllKilometragensAsync()
        {
            IEnumerable<Kilometragem> killometragem = await _context.Kilometragens.ToListAsync();
            return killometragem;
        }

        public async Task<Kilometragem> GetKilometragemByIdAsync(int id)
        {
            return await _context.Kilometragens.FirstOrDefaultAsync(k => k.IdVeiculo == id);
        }
        
        public async Task CreateKilometragemAsync(Kilometragem killometragem)
        {
            await _context.AddAsync(killometragem);
        }

        public async Task RemoveKilometragem(Kilometragem killometragem)
        {
            _context.Kilometragens.Remove(killometragem);
        }

    }
}
