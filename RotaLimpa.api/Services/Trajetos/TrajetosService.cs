using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories.Interfaces;
using RotaLimpa.Api.Repositories.UnitOfWork;
using RotaLimpa.Api.Exceptions;
using System.Security.Cryptography;

namespace RotaLimpa.Api.Services
{
    public class TrajetosService : ITrajetosService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ITrajetosRepository _trajetosRepository;

        private readonly IFrotasService _frotasService;

        private readonly IRotasService _rotasService;

        private readonly IMotoristasService _motoristasService;

        private readonly IPeriodosService _periodosService;

        public TrajetosService(ITrajetosRepository trajetosRepository, IUnitOfWork unitOfWork, IFrotasService frotasService, IRotasService rotasService, IMotoristasService motoristasService, IPeriodosService periodosService)
        {
            _trajetosRepository = trajetosRepository;
            _unitOfWork = unitOfWork;
            _frotasService = frotasService;
            _rotasService = rotasService;
            _motoristasService = motoristasService;
            _periodosService = periodosService;
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
            Rota rota = await _rotasService.GetRotaByIdAsync(trajeto.IdRota);
            if (rota == null)
            {
                throw new Exception("Rota doesn't exists.");
            }

            Motorista motorista = await _motoristasService.GetMotoristaByIdAsync(trajeto.IdMotorista);
            if (motorista == null)
            {
                throw new Exception("Motorista doesn't exists.");
            }
            trajeto.Motorista = motorista;

            Periodo periodo = await _periodosService.GetPeriodoByIdAsync(trajeto.IdPeriodo);
            if (periodo == null)
            {
                throw new Exception("Periodo doesn't exists.");
            }
            trajeto.Periodo = periodo;

            Frota frota = await _frotasService.GetFrotaByIdAsync(trajeto.IdFrota);
            if (frota == null)
            {
                throw new Exception("Frota doesn't exists.");
            }
            trajeto.Frota = frota;

            await _trajetosRepository.CreateTrajetoAsync(trajeto);
            await _unitOfWork.SaveChangesAsync();
            return trajeto;
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
