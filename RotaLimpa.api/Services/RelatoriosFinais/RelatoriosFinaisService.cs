﻿using Microsoft.EntityFrameworkCore;
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

        private readonly ITrajetosService _trajetosService;

        private readonly ISetoresService _setoresService;

        public RelatoriosFinaisService(IRelatoriosFinaisRepository relatoriosFinaisRepository, IUnitOfWork unitOfWork, ITrajetosService trajetosService, ISetoresService setoresService)
        {
            _relatoriosFinaisRepository = relatoriosFinaisRepository;
            _unitOfWork = unitOfWork;
            _trajetosService = trajetosService;
            _setoresService = setoresService;
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
            Trajeto trajeto = await _trajetosService.GetTrajetoByIdAsync(relatorioFinal.IdTrajeto);
            if (trajeto == null)
            {
                throw new Exception("Trajeto doesn't exists.");
            }

            Setor setor = await _setoresService.GetSetorByIdAsync(relatorioFinal.IdSetor);
            if (setor == null)
            {
                throw new Exception("Setor doesn't exists.");
            }

            await _relatoriosFinaisRepository.CreateRelatorioFinalAsync(relatorioFinal);
            await _unitOfWork.SaveChangesAsync();
            return relatorioFinal;
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
        public async Task RemoveRelatorioFinal(int id)
        {
            RelatorioFinal currentRelatorioFinal = await _relatoriosFinaisRepository.GetRelatorioFinalByIdAsync(id);
            await _relatoriosFinaisRepository.RemoveRelatorioFinal(currentRelatorioFinal);
            await _unitOfWork.SaveChangesAsync();

            return;

        }
    }
}
