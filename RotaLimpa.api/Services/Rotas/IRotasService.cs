using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Services
{
    public interface IRotasService
    {
        public Task<IEnumerable<Rota>> GetAllRotasAsync();
        public Task<Rota> GetRotaByIdAsync(int id);
        public Task<Rota> CreateRotaAsync(Rota rota);
        public Task<Rota> UpdateRotaAsync(int id, Rota rota);
        public Task RemoveRota(int id);
    }
}
