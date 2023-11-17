using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Services
{
    public interface IColaboradoresService
    {
        public Task<IEnumerable<Colaborador>> GetAllColaboradoresAsync();

        public Task<Colaborador> GetColaboradorByIdAsync(int id);

        public Task<Colaborador> CreateColaboradorAsync(Colaborador colaborador);

        public Task<Colaborador> UpdateColaboradorAsync(int id, Colaborador colaborador);

        public Task<Colaborador> RemoveColaborador(int id, Colaborador colaborador);
    }
}
