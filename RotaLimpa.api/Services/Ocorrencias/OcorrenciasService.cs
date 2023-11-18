using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories.Interfaces;
using RotaLimpa.Api.Repositories.UnitOfWork;
using RotaLimpa.Api.Exceptions;

namespace RotaLimpa.Api.Services
{
    public class OcorrenciasService : IOcorrenciasService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IOcorrenciasRepository _ocorrenciasRepository;

        public OcorrenciasService(IOcorrenciasRepository ocorrenciasRepository, IUnitOfWork unitOfWork)
        {
            _ocorrenciasRepository = ocorrenciasRepository;
            _unitOfWork = unitOfWork;
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
            Ocorrencia currentOcorrencia = await _ocorrenciasRepository.GetOcorrenciaByIdAsync(ocorrencia.Id);
            if (currentOcorrencia != null && currentOcorrencia.Equals(ocorrencia))
            {
                throw new Exception("Ocorrencia already exists.");
            }
            await _ocorrenciasRepository.CreateOcorrenciaAsync(ocorrencia);
            await _unitOfWork.SaveChangesAsync();
            return currentOcorrencia;
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

        public async Task<Ocorrencia> RemoveOcorrencia(int id, Ocorrencia ocorrencia)
        {
            Ocorrencia currentOcorrencia = await _ocorrenciasRepository.GetOcorrenciaByIdAsync(id);
            await _ocorrenciasRepository.RemoveOcorrencia(ocorrencia);
            await _unitOfWork.SaveChangesAsync();

            return ocorrencia;
        }
    }
}
