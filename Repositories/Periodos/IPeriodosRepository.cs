using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Repositories.Interfaces
{
    public interface IPeriodosRepository
    {
        public Task<IEnumerable<Periodo>> GetAllPeriodosAsync();
        public Task<Periodo> GetPeriodoByIdAsync(int id);
        public Task CreatePeriodoAsync(Periodo periodo);
        public Task RemovePeriodo( Periodo periodo);
    }
}
