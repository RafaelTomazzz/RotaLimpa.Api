using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories.Interfaces;

namespace RotaLimpa.Api.Repositories
{
    public class SetoresVeiculosRepository : ISetoresVeiculosRepository
    {
        private readonly DataContext _context;

        public SetoresVeiculosRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<SetorVeiculo>> GetAllSetoresVeiculosAsync()
        {
            IEnumerable<SetorVeiculo> setorVeiculos = await _context.SetorVeiculos.ToListAsync();
            return setorVeiculos;
        }
        public async Task<SetorVeiculo> GetSetorVeiculoByIdAsync(int id)
        {
            return await _context.SetorVeiculos.FirstOrDefaultAsync(SetorVeiBusca => SetorVeiBusca.IdSetor == id);
        }
        public async Task CreateSetorVeiculoAsync(SetorVeiculo setorVeiculo)
        {
            await _context.AddAsync(setorVeiculo);
        }
        public async Task RemoveSetorVeiculo(SetorVeiculo setorVeiculo)
        {
            _context.SetorVeiculos.Remove(setorVeiculo);
        }


    }
}
