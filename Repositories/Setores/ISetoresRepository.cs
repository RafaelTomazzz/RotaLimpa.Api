using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Repositories.Setores
{
    public interface ISetoresRepository
    {
        public Task<IEnumerable<Setor>> GetAllAsync();
        public Task<Setor> GetByIdAsync(int id);
    }
}