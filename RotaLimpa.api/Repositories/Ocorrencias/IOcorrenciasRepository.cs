using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Repositories.Interfaces
{
    public interface IOcorrenciasRepository
    {
        public Task<IEnumerable<Ocorrencia>> GetAllOcorrenciasAsync();
        public Task<Ocorrencia> GetOcorrenciaByIdAsync(int id);
        public Task CreateOcorrenciaAsync(Ocorrencia ocorrencia);
        public Task RemoveOcorrencia(Ocorrencia ocorrencia);
        public Task<IEnumerable<Ocorrencia>> GetAllOcorrenciaIdTrajetoAsync(int idtrajeto);
    }
}
