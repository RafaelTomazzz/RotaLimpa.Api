using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Services
{
    public interface ISetoresService
    {
        public Task<IEnumerable<Setor>> GetAllSetoresAsync();

        public Task<Setor> GetSetorByIdAsync(int id);

        public Task<Setor> CreateSetorAsync(Setor frota);

        public Task<Setor> UpdateSetorAsync(int id, Setor frota);

        public Task RemoveSetor(int id);
    }
}