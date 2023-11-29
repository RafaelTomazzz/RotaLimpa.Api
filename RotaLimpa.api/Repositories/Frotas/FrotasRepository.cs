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
    public class FrotasRepository : IFrotasRepository
    {
        private readonly DataContext _context;
        public FrotasRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Frota>> GetAllFrotasAsync()
        {
            IEnumerable<Frota> frota = await _context.Frotas.ToListAsync();
            return frota;
        }

        public async Task<Frota> GetFrotaByIdAsync(int id)
        {
            return await _context.Frotas.FirstOrDefaultAsync(f => f.IdVeiculo == id);
        }
        
        public async Task CreateFrotaAsync(Frota frota)
        {
            await _context.AddAsync(frota);
        }

        public async Task RemoveFrota(Frota frota)
        {
            _context.Frotas.Remove(frota);
        }

        public async Task<Frota> GetFrotaByPlacaAsync(string placa)
        {
            return await _context.Frotas.FirstOrDefaultAsync(f => f.PVeiculo == placa);
        }
    }
}
