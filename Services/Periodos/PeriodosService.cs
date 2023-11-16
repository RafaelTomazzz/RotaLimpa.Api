using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Exceptions;
using RotaLimpa.Api.Repositories.UnitOfWork;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories.Interfaces;


namespace RotaLimpa.Api.Services.Periodos
{
    public class PeriodoService : IPeriodosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPeriodosRepository _periodoRepository;

      

        public PeriodoService(IPeriodosRepository periodoRepository, IUnitOfWork unitOfWork ) 
        {
            _periodoRepository = periodoRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Periodo>> GetAllPeriodosAsync()
        {
            IEnumerable<Periodo> periodo = await _periodoRepository.GetAllPeriodosAsync();
            return periodo;
        }
        public async Task<Periodo> GetPeriodoByIdAsync(int id)
        {
            Periodo periodo = await _periodoRepository.GetPeriodoByIdAsync(id);
            if (periodo == null)
            {
                throw new NotFoundException("Not Found");
            }
            
            return periodo;
        }
        public async Task<Periodo> CreatePeriodoAsync(Periodo periodo)
        {
            Periodo currentPeriodo = await _periodoRepository.GetPeriodoByIdAsync(periodo.Id);
            if (currentPeriodo != null && currentPeriodo.Equals(periodo))
            {
                throw new Exception("Periodo já existe.");
            }
            await _periodoRepository.CreatePeriodoAsync(periodo);
            await _unitOfWork.SaveChangesAsync();
            return currentPeriodo;
        }

        public async Task<Periodo> UpdatePeriodoAsync(int id, Periodo periodo)
        {
            Periodo currentPeriodo = await _periodoRepository.GetPeriodoByIdAsync(id);
            if (currentPeriodo == null)
            {
                throw new NotFoundException("Not found");
            }
            currentPeriodo.MfPeriodo = periodo.MfPeriodo;
            currentPeriodo.DsPeriodo = periodo.DsPeriodo;
            currentPeriodo.MiPeriodo = periodo.MiPeriodo;

            await _unitOfWork.SaveChangesAsync();
            return periodo;

        }
        public async Task<Periodo> RemovePeriodo(int id, Periodo periodo)
        {
            Periodo CurrentPeriodo = await _periodoRepository.GetPeriodoByIdAsync(id);
            await _periodoRepository.RemovePeriodo(periodo);
            await _unitOfWork.SaveChangesAsync();

            return periodo;

        }
    }
}
