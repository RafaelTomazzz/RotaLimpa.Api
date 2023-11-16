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
    public class OcorrenciasRepository : IOcorrenciasRepository
    {
        private readonly DataContext _context;
        public OcorrenciasRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ocorrencia>> GetAllOcorrenciasAsync()
        {
            IEnumerable<Ocorrencia> ocorrencia = await _context.Ocorrencias.ToListAsync();
            return ocorrencia;
        }

        public async Task<Ocorrencia> GetOcorrenciaByIdAsync(int id)
        {
            return await _context.Ocorrencias.FirstOrDefaultAsync(o => o.Id == id);
        }
        
        public async Task CreateOcorrenciaAsync(Ocorrencia ocorrencia)
        {
            await _context.AddAsync(ocorrencia);
        }

        public async Task RemoveOcorrencia(Ocorrencia ocorrencia)
        {
            _context.Ocorrencias.Remove(ocorrencia);
        }

    }
}
