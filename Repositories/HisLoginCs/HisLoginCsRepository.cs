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
    public class HisLoginCsRepository : IHisLoginCsRepository
    {
        private readonly DataContext _context;
        public HisLoginCsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HisLoginC>> GetAllHisLoginCsAsync()
        {
            IEnumerable<HisLoginC> hisLoginC = await _context.HisLoginCs.ToListAsync();
            return hisLoginC;
        }

        public async Task<HisLoginC> GetHisLoginCByIdAsync(int id)
        {
            return await _context.HisLoginCs.FirstOrDefaultAsync(h => h.Id == id);
        }
        
        public async Task CreateHisLoginCAsync(HisLoginC hisLoginC)
        {
            await _context.AddAsync(hisLoginC);
        }

        public async Task RemoveHisLoginC(HisLoginC hisLoginC)
        {
            _context.HisLoginCs.Remove(hisLoginC);
        }

    }
}
