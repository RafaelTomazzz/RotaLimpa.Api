using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Repositories.Interfaces
{
    public interface IColaboradoresRepository
    {
        public Task<IEnumerable<Colaborador>> GetAllColaboradoresAsync();
        public Task<Colaborador> GetColaboradorByIdAsync(int id);
        public Task CreateColaboradorAsync(Colaborador colaborador);
        public Task RemoveColaborador(Colaborador colaborador);
        public Task<int> ObterUltimoNumeroLoginAsync(int currentYear);
    }
}
