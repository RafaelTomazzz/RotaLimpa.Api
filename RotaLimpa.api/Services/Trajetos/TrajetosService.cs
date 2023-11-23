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
    public class TrajetosService : ITrajetosService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ITrajetosRepository _trajetosRepository;

        public TrajetosService(ITrajetosRepository trajetosRepository, IUnitOfWork unitOfWork)
        {
            _trajetosRepository = trajetosRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Trajeto>> GetAllTrajetosAsync()
        {
            IEnumerable<Trajeto> trajetos = await _trajetosRepository.GetAllTrajetosAsync();
            return trajetos;
        }

        public async Task<Trajeto> GetTrajetoByIdAsync(int id)
        {
            Trajeto trajeto = await _trajetosRepository.GetTrajetoByIdAsync(id);
            if (trajeto == null)
            {
                throw new NotFoundException("Not Found");
            }
            return trajeto;
        }

        public async Task<Trajeto> CreateTrajetoAsync(Trajeto trajeto)
        {
            Trajeto currentTrajeto = await _trajetosRepository.GetTrajetoByIdAsync(trajeto.Id);
            if (currentTrajeto != null && currentTrajeto.Equals(trajeto))
            {
                throw new Exception("Trajeto already exists.");
            }
            await _trajetosRepository.CreateTrajetoAsync(trajeto);
            await _unitOfWork.SaveChangesAsync();
            return currentTrajeto;
        }

        public async Task<Trajeto> UpdateTrajetoAsync(int id, Trajeto trajeto)
        {
            Trajeto currentTrajeto = await _trajetosRepository.GetTrajetoByIdAsync(id);
            if (currentTrajeto == null)
            {
                throw new NotFoundException("Not found");
            }

            currentTrajeto.IdMotorista = trajeto.IdMotorista;
            currentTrajeto.IdRota = trajeto.IdRota;
            currentTrajeto.IdPeriodo = trajeto.IdPeriodo;
            currentTrajeto.IdFrota = trajeto.IdFrota;
            currentTrajeto.MiTrajeto = trajeto.MiTrajeto;
            currentTrajeto.MfTrajeto = trajeto.MfTrajeto;
            await _unitOfWork.SaveChangesAsync();

            return trajeto;
        }

        public async Task RemoveTrajeto(int id)
        {
            Trajeto currentTrajeto = await _trajetosRepository.GetTrajetoByIdAsync(id);
            await _trajetosRepository.RemoveTrajeto(currentTrajeto);
            await _unitOfWork.SaveChangesAsync();

            return;
        }
    }
}
