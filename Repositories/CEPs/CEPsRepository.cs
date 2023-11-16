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
    public class CEPsRepository : ICEPsRepository
    {
        private readonly DataContext _context;
        public CEPsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CEP>> GetAllCEPsAsync()
        {
            IEnumerable<CEP> cep = await _context.CEPs.ToListAsync();
            return cep;
        }

        public async Task<CEP> GetCEPByIdAsync(int id)
        {
            return await _context.CEPs.FirstOrDefaultAsync(c => c.Id == id);
        }
        
        public async Task CreateCEPAsync(CEP cep)
        {
            await _context.AddAsync(cep);
        }

        public async Task RemoveCEP(CEP cep)
        {
            _context.CEPs.Remove(cep);
        }

    }
}
