using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Services
{
    public interface IOcorrenciasService
    {
        public Task<IEnumerable<Ocorrencia>> GetAllOcorrenciasAsync();

        public Task<Ocorrencia> GetOcorrenciaByIdAsync(int id);

        public Task<Ocorrencia> CreateOcorrenciaAsync(Ocorrencia ocorrencia);

        public Task<Ocorrencia> UpdateOcorrenciaAsync(int id, Ocorrencia ocorrencia);

        public Task<Ocorrencia> RemoveOcorrencia(int id, Ocorrencia ocorrencia);
    }
}
