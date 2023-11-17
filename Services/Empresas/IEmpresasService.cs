using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Services
{
    public interface IEmpresasService
    {
        public Task<IEnumerable<Empresa>> GetAllEmpresasAsync();

        public Task<Empresa> GetEmpresaByIdAsync(int id);

        public Task<Empresa> CreateEmpresaAsync(Empresa empresa);

        public Task<Empresa> UpdateEmpresaAsync(int id, Empresa empresa);

        public Task<Empresa> RemoveEmpresa(int id, Empresa empresa);
    }
}
