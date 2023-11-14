using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositores.Setores;

namespace RotaLimpa.Api.Repositores.Setores
{
    public class SetoresRepository : ISetoresRepository
    {
        private readonly DataContext _dataContext;

        public SetoresRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Setor>> GetAllAsync()
        {
            return await _dataContext.Setores.ToListAsync();
        }
        
        public async Task<Setor> GetByIdAsync(int id)
        {
            return await _dataContext.Setores.FirstOrDefaultAsync(c => c.Id == id);
        }


    }

}