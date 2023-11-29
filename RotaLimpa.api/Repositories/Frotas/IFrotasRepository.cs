using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Repositories.Interfaces
{
    public interface IFrotasRepository
    {
        public Task<IEnumerable<Frota>> GetAllFrotasAsync();
        public Task<Frota> GetFrotaByIdAsync(int id);
        public Task CreateFrotaAsync(Frota frota);
        public Task RemoveFrota(Frota frota);
        public Task<Frota> GetFrotaByPlacaAsync(string placa);
    }
}
