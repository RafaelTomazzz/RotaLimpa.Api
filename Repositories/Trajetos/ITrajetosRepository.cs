using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Repositories.Interfaces
{
    public interface ITrajetosRepository
    {
        public Task<IEnumerable<Trajeto>> GetAllTrajetosAsync();
        public Task<Trajeto> GetTrajetoByIdAsync(int id);
        public Task CreateTrajetoAsync(Trajeto trajeto);
        public Task RemoveTrajeto(Trajeto trajeto);
    }
}
