using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Services
{
    public interface ISetoresVeiculosService
    {
        public Task<IEnumerable<SetorVeiculo>> GetAllSetoresVeiculosAsync();
        public Task<SetorVeiculo> GetSetorVeiculoByIdAsync(int id);
        public Task<SetorVeiculo> CreateSetorVeiculoAsync(SetorVeiculo setorVeiculo);
        public Task<SetorVeiculo> UpdateSetorVeiculoAsync( int id, SetorVeiculo setorVeiculo);
        public Task<SetorVeiculo> RemoveSetorVeiculo(int id, SetorVeiculo setorVeiculo);
    }
}
