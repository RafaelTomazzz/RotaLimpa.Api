using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Repositories.Interfaces
{
    public interface ISetoresRepository
    {
        public Task<IEnumerable<Setor>> GetAllSetoresAsync();
        public Task<Setor> GetSetorByIdAsync(int id);
        public Task CreateSetorAsync(Setor setor);
        public Task RemoveSetor(Setor setor);
    }
}
