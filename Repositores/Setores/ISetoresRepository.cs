using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Repositores.Setores
{
    public interface ISetoresRepository
    {
        public Task<IEnumerable<Setor>> GetAllAsync();
    }
}