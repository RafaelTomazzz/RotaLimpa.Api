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

        public Task<Kilometragem> GetKilometragemByIdAsync(int id);

        public Task<Kilometragem> CreateKilometragemAsync(Kilometragem kilometragem);

        public Task<Kilometragem> UpdateKilometragemAsync(int id, Kilometragem kilometragem);

        public Task RemoveKilometragem(int id);
    }
}
