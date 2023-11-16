using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Services
{
    public interface IKilometragensService
    {
        public Task<IEnumerable<Kilometragem>> GetAllKilometragensAsync();

        public Task<Kilometragem> GetKilometragenByIdAsync(int id);

        public Task<Kilometragem> CreateKilometragenAsync(Kilometragem kilometragem);

        public Task<Kilometragem> UpdateKilometragenAsync(int id, Kilometragem kilometragem);

        public Task<Kilometragem> RemoveKilometragen(int id, Kilometragem kilometragem);
    }
}
