using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Repositories.Interfaces
{
    public interface ICEPsRepository
    {
        public Task<IEnumerable<CEP>> GetAllCEPsAsync();
        public Task<CEP> GetCEPByIdAsync(int id);
        public Task CreateCEPAsync(CEP cep);
        public Task RemoveCEP(CEP cep);
    }
}
