using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Repositories.Interfaces
{
    public interface ISetorVeiculosRepository
    {
        public Task<IEnumerable<SetorVeiculo>> GetAllSetoresVeiculosAsync();
        public Task<SetorVeiculo> GetSetorVeiculoByIdAsync(int id);
        public Task CreateSetorVeiculoAsync(SetorVeiculo setorVeiculo);
        public Task RemoveSetorVeiculo(SetorVeiculo setorVeiculo);
    }
}
