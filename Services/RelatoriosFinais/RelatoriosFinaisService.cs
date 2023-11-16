using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Exceptions;
using RotaLimpa.Api.Repositories.UnitOfWork;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories;
using RotaLimpa.Api.Repositories.Interfaces;
namespace RotaLimpa.Api.Services
{
    public class RelatoriosFinaisService : IRelatoriosFinaisService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IRelatoriosFinaisRepository _relatoriosFinaisRepository;

        public RelatoriosFinaisService(IRelatoriosFinaisRepository relatoriosFinaisRepository, IUnitOfWork unitOfWork)
        {
            _relatoriosFinaisRepository = relatoriosFinaisRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RelatorioFinal>> GetAllRelatoriosFinaisAsync()
        {
            IEnumerable<RelatorioFinal> relatorioFinal = await _relatoriosFinaisRepository.GetAllRelatoriosFinaisAsync();
            return relatorioFinal;
        }
        public async Task<RelatorioFinal> GetRelatorioFinalByIdAsync(int id)
        {
            RelatorioFinal relatorioFinal = await _relatoriosFinaisRepository.GetRelatorioFinalByIdAsync(id);
            if (relatorioFinal == null)
            {
                throw new NotFoundException("Not Found");
            }

            return relatorioFinal;
        }
        public async Task<RelatorioFinal> CreateRelatorioFinalAsync(RelatorioFinal relatorioFinal)
        {
            RelatorioFinal currentRelatorioFinal = await _relatoriosFinaisRepository.GetRelatorioFinalByIdAsync(relatorioFinal.IdRelatorio);
            if (currentRelatorioFinal != null && currentRelatorioFinal.Equals(relatorioFinal))
            {
                throw new Exception("Relatório final já existe.");
            }
            await _relatoriosFinaisRepository.CreateRelatorioFinalAsync(relatorioFinal);
            await _unitOfWork.SaveChangesAsync();
            return currentRelatorioFinal;
        }

        public async Task<RelatorioFinal> UpdateRelatorioFinalAsync(int id, RelatorioFinal relatorioFinal)
        {
            RelatorioFinal currentRelatorioFinal = await _relatoriosFinaisRepository.GetRelatorioFinalByIdAsync(relatorioFinal.IdRelatorio);
            if (currentRelatorioFinal == null)
            {
                throw new NotFoundException("Not found");
            }
            currentRelatorioFinal.IdSetor = relatorioFinal.IdSetor;
            currentRelatorioFinal.IdRelatorio = relatorioFinal.IdRelatorio;

            await _unitOfWork.SaveChangesAsync();
            return relatorioFinal;

        }
        public async Task<RelatorioFinal> RemoveRelatorioFinal(int id, RelatorioFinal relatorioFinal)
        {
            RelatorioFinal currentRelatorioFinal = await _relatoriosFinaisRepository.GetRelatorioFinalByIdAsync(relatorioFinal.IdRelatorio);
            await _relatoriosFinaisRepository.RemoveRelatorioFinal(relatorioFinal);
            await _unitOfWork.SaveChangesAsync();

            return relatorioFinal;

        }
    }
}
