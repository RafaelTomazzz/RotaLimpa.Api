using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Services
{
    public interface IRuasService
    {
        public Task<IEnumerable<Rua>> GetAllRuasAsync();
        public Task<Rua> GetRuaByIdAsync(int id);
        public Task<Rua> CreateRuaAsync(Rua rua);
        public Task<Rua> UpdateRuaAsync(int id, Rua rua);
        public Task RemoveRua(int id);
        public Task<IEnumerable<Rua>> GetAllRuasWhereRota(int idrota);
    }
}
