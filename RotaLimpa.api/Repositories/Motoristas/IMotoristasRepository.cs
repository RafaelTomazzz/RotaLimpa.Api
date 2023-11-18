using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Repositories.Interfaces
{
    public interface IMotoristasRepository
    {
        public Task<IEnumerable<Motorista>> GetAllMotoristasAsync();
        public Task<Motorista> GetMotoristaByIdAsync(int id);
        public Task CreateMotoristaAsync(Motorista motorista);
        public Task RemoveMotorista(Motorista motorista);
        //public Task<int> ObterUltimoNumeroLoginAsync(int currentYear);
    }
}
