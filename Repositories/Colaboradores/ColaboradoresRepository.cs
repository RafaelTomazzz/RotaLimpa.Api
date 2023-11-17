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
    public class ColaboradoresRepository : IColaboradoresRepository
    {
        private readonly DataContext _context;
        public ColaboradoresRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Colaborador>> GetAllColaboradoresAsync()
        {
            IEnumerable<Colaborador> colaborador = await _context.Colaboradores.ToListAsync();
            return colaborador;
        }

        public async Task<Colaborador> GetColaboradorByIdAsync(int id)
        {
            return await _context.Colaboradores.FirstOrDefaultAsync(f => f.Id == id);
        }
        
        public async Task CreateColaboradorAsync(Colaborador colaborador)
        {
            await _context.AddAsync(colaborador);
        }

        public async Task RemoveColaborador(Colaborador colaborador)
        {
            _context.Colaboradores.Remove(colaborador);
        }

    }
}
