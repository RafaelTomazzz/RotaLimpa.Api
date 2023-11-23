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
    public class FrotasService : IFrotasService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IFrotasRepository _frotasRepository;

        public FrotasService(IFrotasRepository frotasRepository, IUnitOfWork unitOfWork)
        {
            _frotasRepository = frotasRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Frota>> GetAllFrotasAsync()
        {
            IEnumerable<Frota> frotas = await _frotasRepository.GetAllFrotasAsync();
            return frotas;
        }

        public async Task<Frota> GetFrotaByIdAsync(int id)
        {
            Frota frota = await _frotasRepository.GetFrotaByIdAsync(id);
            if (frota == null)
            {
                throw new NotFoundException("Not Found");
            }
            return frota;
        }

        public async Task<Frota> CreateFrotaAsync(Frota frota)
        {
            Frota currentFrota = await _frotasRepository.GetFrotaByIdAsync(frota.IdVeiculo);
            if (currentFrota != null && currentFrota.Equals(frota))
            {
                throw new Exception("Frota already exists.");
            }
            await _frotasRepository.CreateFrotaAsync(frota);
            await _unitOfWork.SaveChangesAsync();
            return currentFrota;
        }

        public async Task<Frota> UpdateFrotaAsync(int id, Frota frota)
        {
            Frota currentFrota = await _frotasRepository.GetFrotaByIdAsync(id);
            if (currentFrota == null)
            {
                throw new NotFoundException("Not found");
            }

            currentFrota.PVeiculo = frota.PVeiculo;
            currentFrota.TmnVeiculo = frota.TmnVeiculo;
            currentFrota.DiVeiculo = frota.DiVeiculo;
            currentFrota.StVeiculo = frota.StVeiculo;
            await _unitOfWork.SaveChangesAsync();

            return frota;
        }

        public async Task RemoveFrota(int id)
        {
            Frota currentFrota = await _frotasRepository.GetFrotaByIdAsync(id);
            await _frotasRepository.RemoveFrota(currentFrota);
            await _unitOfWork.SaveChangesAsync();

            return;
        }

    }
}
