using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Repositories.Interfaces
{
    public interface ISetoresVeiculosRepository
    {
        public Task<IEnumerable<SetorVeiculo>> GetAllSetoresVeiculosAsync();
        public Task<SetorVeiculo> GetSetorVeiculoByIdAsync(int id);
        public Task CreateSetorVeiculoAsync(SetorVeiculo setorVeiculo);
        public Task RemoveSetorVeiculo(SetorVeiculo setorVeiculo);
    }
}
