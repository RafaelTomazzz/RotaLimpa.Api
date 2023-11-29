using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories.Interfaces;

namespace RotaLimpa.Api.Repositories
{
    public class EmpresasRepository : IEmpresasRepository
    {
        private readonly DataContext _context;
        public EmpresasRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empresa>> GetAllEmpresasAsync()
        {
            IEnumerable<Empresa> empresa = await _context.Empresas.ToListAsync();
            return empresa;
        }

        public async Task<Empresa> GetEmpresaByIdAsync(int id)
        {
            return await _context.Empresas.FirstOrDefaultAsync(f => f.Id == id);
        }
        
        public async Task CreateEmpresaAsync(Empresa empresa)
        {
            await _context.AddAsync(empresa);
        }

        public async Task RemoveEmpresa(Empresa empresa)
        {
            _context.Empresas.Remove(empresa);
        }

        public async Task<Empresa> GetEmpresaByCNPJAsync(string cnpj)
        {
            return await _context.Empresas.FirstOrDefaultAsync(f => f.DcEmpresa == cnpj);
        }
    }
}
