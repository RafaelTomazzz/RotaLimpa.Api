using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Repositories.Interfaces
{
    public interface IRotasRepository
    {
        public Task<ICollection<Rota>> GetAllRotasAsync();
        public Task<Rota> GetRotaByIdAsync(int id);
        public Task CreateRotaAsync(Rota rota);
        public Task RemoveRota(Rota rota);
    }
}
