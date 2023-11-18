using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Repositories.Interfaces
{
    public interface IEmpresasRepository
    {
        public Task<IEnumerable<Empresa>> GetAllEmpresasAsync();
        public Task<Empresa> GetEmpresaByIdAsync(int id);
        public Task CreateEmpresaAsync(Empresa empresa);
        public Task RemoveEmpresa(Empresa empresa);
    }
}
