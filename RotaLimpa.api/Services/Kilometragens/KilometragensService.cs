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
    public class KilometragensService : IKilometragensService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IKilometragensRepository _kilometragensRepository;

        private readonly IFrotasService _frotasService;

        public KilometragensService(IKilometragensRepository kilometragensRepository, IUnitOfWork unitOfWork, IFrotasService frotasService)
        {
            _kilometragensRepository = kilometragensRepository;
            _unitOfWork = unitOfWork;
            _frotasService = frotasService;
        }

        public async Task<IEnumerable<Kilometragem>> GetAllKilometragensAsync()
        {
            IEnumerable<Kilometragem> kilometragens = await _kilometragensRepository.GetAllKilometragensAsync();
            return kilometragens;
        }

        public async Task<Kilometragem> GetKilometragemByIdAsync(int id)
        {
            Kilometragem Kilometragem = await _kilometragensRepository.GetKilometragemByIdAsync(id);
            if (Kilometragem == null)
            {
                throw new NotFoundException("Not Found");
            }
            return Kilometragem;
        }

        public async Task<Kilometragem> CreateKilometragemAsync(Kilometragem kilometragem)
        {
            Frota frota = await _frotasService.GetFrotaByIdAsync(kilometragem.IdVeiculo);
            if (frota == null)
            {
                throw new Exception("Frota doesn't exists.");
            }
            await _kilometragensRepository.CreateKilometragemAsync(kilometragem);
            await _unitOfWork.SaveChangesAsync();
            return kilometragem;
        }

        public async Task<Kilometragem> UpdateKilometragemAsync(int id, Kilometragem kilometragem)
        {
            Kilometragem currentKilometragem = await _kilometragensRepository.GetKilometragemByIdAsync(id);
            if (currentKilometragem == null)
            {
                throw new NotFoundException("Not found");
            }

            currentKilometragem.Km = kilometragem.Km;
            currentKilometragem.DiKilometragem = kilometragem.DiKilometragem;
            await _unitOfWork.SaveChangesAsync();

            return kilometragem;
        }

        public async Task RemoveKilometragem(int id)
        {
            Kilometragem currentKilometragem = await _kilometragensRepository.GetKilometragemByIdAsync(id);
            await _kilometragensRepository.RemoveKilometragem(currentKilometragem);
            await _unitOfWork.SaveChangesAsync();

            return;
        }
    }
}
