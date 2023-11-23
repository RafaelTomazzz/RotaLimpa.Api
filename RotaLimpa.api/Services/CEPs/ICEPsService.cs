using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Services
{
    public interface ICEPsService
    {
        public Task<IEnumerable<CEP>> GetAllCEPsAsync();

        public Task<CEP> GetCEPByIdAsync(int id);

        public Task<CEP> CreateCEPAsync(CEP cep);

        public Task<CEP> UpdateCEPAsync(int id, CEP cep);

        public Task RemoveCEP(int id);
    }
}
