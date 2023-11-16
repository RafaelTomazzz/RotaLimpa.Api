using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Services.Setores
{
    public interface ISetoresService
    {
        public Task<IEnumerable<Setor>> GetAllAsync();
        public Task<Setor> GetByIdAsync();
    }
}