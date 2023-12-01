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
    public class HisLoginMsRepository : IHisLoginMsRepository
    {
        private readonly DataContext _context;
        public HisLoginMsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HisLoginM>> GetAllHisLoginMsAsync()
        {
            IEnumerable<HisLoginM> hisLoginM = await _context.HisLoginMs.ToListAsync();
            return hisLoginM;
        }

        public async Task<HisLoginM> GetHisLoginMByIdAsync(int id)
        {
            return await _context.HisLoginMs.FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<IEnumerable<HisLoginM>> GetAllHisLoginMsMotoristaAsync(int idMotorista)
        {
            IEnumerable<HisLoginM> hisLoginMMotorista = await _context.HisLoginMs.Where(h => h.IdMotorista == idMotorista).ToListAsync();
            return hisLoginMMotorista;
        }

        public async Task CreateHisLoginMAsync(HisLoginM hisLoginM)
        {
            await _context.AddAsync(hisLoginM);
        }

        public async Task RemoveHisLoginM(HisLoginM hisLoginM)
        {
            _context.HisLoginMs.Remove(hisLoginM);
        }

    }
}
