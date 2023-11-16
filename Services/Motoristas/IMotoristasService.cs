using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Services
{
    public interface IMotoristasService
    {
        public Task<IEnumerable<Motorista>> GetAllMotoristasAsync();

        public Task<Motorista> GetMotoristaByIdAsync(int id);

        public Task<Motorista> CreateMotoristaAsync(Motorista motorista);

        public Task<Motorista> UpdateMotoristaAsync(int id, Motorista motorista);

        public Task<Motorista> RemoveMotorista(int id, Motorista motorista);
    }
}
