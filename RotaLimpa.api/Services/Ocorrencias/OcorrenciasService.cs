using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories.Interfaces;
using RotaLimpa.Api.Repositories.UnitOfWork;
using RotaLimpa.Api.Exceptions;
using RotaLimpa.Api.Repositories;

namespace RotaLimpa.Api.Services
{
    public class OcorrenciasService : IOcorrenciasService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IOcorrenciasRepository _ocorrenciasRepository;

        private readonly ITrajetosService _trajetosService;

        public OcorrenciasService(IOcorrenciasRepository ocorrenciasRepository, IUnitOfWork unitOfWork, ITrajetosService trajetosService)
        {
            _ocorrenciasRepository = ocorrenciasRepository;
            _unitOfWork = unitOfWork;
            _trajetosService = trajetosService;
        }

        public async Task<IEnumerable<Ocorrencia>> GetAllOcorrenciasAsync()
        {
            IEnumerable<Ocorrencia> ocorrencias = await _ocorrenciasRepository.GetAllOcorrenciasAsync();
            return ocorrencias;
        }

        public async Task<Ocorrencia> GetOcorrenciaByIdAsync(int id)
        {
            Ocorrencia ocorrencia = await _ocorrenciasRepository.GetOcorrenciaByIdAsync(id);
            if (ocorrencia == null)
            {
                throw new NotFoundException("Not Found");
            }
            return ocorrencia;
        }

        public async Task<Ocorrencia> CreateOcorrenciaAsync(Ocorrencia ocorrencia)
        {
            Trajeto trajeto = await _trajetosService.GetTrajetoByIdAsync(ocorrencia.IdTrajeto);
            if (trajeto == null)
            {
                throw new Exception("Trajeto doesn't exists.");
            }
            await _ocorrenciasRepository.CreateOcorrenciaAsync(ocorrencia);
            await _unitOfWork.SaveChangesAsync();
            return ocorrencia;
        }

        public async Task<Ocorrencia> UpdateOcorrenciaAsync(int id, Ocorrencia ocorrencia)
        {
            Ocorrencia currentOcorrencia = await _ocorrenciasRepository.GetOcorrenciaByIdAsync(id);
            if (currentOcorrencia == null)
            {
                throw new NotFoundException("Not found");
            }

            currentOcorrencia.IdTrajeto = ocorrencia.IdTrajeto;
            currentOcorrencia.TipoOcorrencia = ocorrencia.TipoOcorrencia;
            currentOcorrencia.MtOcorrencia = ocorrencia.MtOcorrencia;
            await _unitOfWork.SaveChangesAsync();

            return ocorrencia;
        }

        public async Task RemoveOcorrencia(int id)
        {
            Ocorrencia currentOcorrencia = await _ocorrenciasRepository.GetOcorrenciaByIdAsync(id);
            await _ocorrenciasRepository.RemoveOcorrencia(currentOcorrencia);
            await _unitOfWork.SaveChangesAsync();

            return;
        }
    }
}
