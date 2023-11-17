using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Services
{
    public interface ITrajetosService
    {
        public Task<IEnumerable<Trajeto>> GetAllTrajetosAsync();

        public Task<Trajeto> GetTrajetoByIdAsync(int id);

        public Task<Trajeto> CreateTrajetoAsync(Trajeto trajeto);

        public Task<Trajeto> UpdateTrajetoAsync(int id, Trajeto trajeto);

        public Task<Trajeto> RemoveTrajeto(int id, Trajeto trajeto);
    }
}
