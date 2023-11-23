using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Services
{
    public interface IFrotasService
    {
        public Task<IEnumerable<Frota>> GetAllFrotasAsync();

        public Task<Frota> GetFrotaByIdAsync(int id);

        public Task<Frota> CreateFrotaAsync(Frota frota);

        public Task<Frota> UpdateFrotaAsync(int id, Frota frota);

        public Task RemoveFrota(int id);
    }
}
