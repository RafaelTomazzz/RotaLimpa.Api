using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Repositories.Interfaces
{
    public interface IKilometragensRepository
    {
        public Task<IEnumerable<Kilometragem>> GetAllKilometragensAsync();
        public Task<Kilometragem> GetKilometragemByIdAsync(int id);
        public Task CreateKilometragemAsync(Kilometragem kilometragem);
        public Task RemoveKilometragem(Kilometragem kilometragem);
    }
}
