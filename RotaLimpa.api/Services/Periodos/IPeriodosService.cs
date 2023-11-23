using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Services
{
    public interface IPeriodosService
    {

        public Task<IEnumerable<Periodo>> GetAllPeriodosAsync();
        public Task<Periodo> GetPeriodoByIdAsync(int id);
        public Task<Periodo> CreatePeriodoAsync(Periodo periodo);
        public Task<Periodo> UpdatePeriodoAsync(int id, Periodo periodo);
        public Task RemovePeriodo(int id);
    }
}
