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

        private readonly IKilometragensRepository _kilimetragensRepository;

        private readonly IFrotasService _frotasService;

        public KilometragensService(IKilometragensRepository kilimetragensRepository, IUnitOfWork unitOfWork, IFrotasService frotasService)
        {
            _kilimetragensRepository = kilimetragensRepository;
            _unitOfWork = unitOfWork;
            _frotasService = frotasService;
        }

        public async Task<IEnumerable<Kilometragem>> GetAllKilometragensAsync()
        {
            IEnumerable<Kilometragem> kilimetragens = await _kilimetragensRepository.GetAllKilometragensAsync();
            return kilimetragens;
        }

        public async Task<Kilometragem> GetKilometragemByIdAsync(int id)
        {
            Kilometragem Kilometragem = await _kilimetragensRepository.GetKilometragemByIdAsync(id);
            if (Kilometragem == null)
            {
                throw new NotFoundException("Not Found");
            }
            return Kilometragem;
        }

        public async Task<Kilometragem> CreateKilometragemAsync(Kilometragem Kilometragem)
        {
            Frota frota = await _frotasService.GetFrotaByIdAsync(Kilometragem.IdVeiculo);
            if (frota == null)
            {
                throw new Exception("Empresa doesn't exists.");
            }
            await _kilimetragensRepository.CreateKilometragemAsync(Kilometragem);
            await _unitOfWork.SaveChangesAsync();
            return Kilometragem;
        }

        public async Task<Kilometragem> UpdateKilometragemAsync(int id, Kilometragem Kilometragem)
        {
            Kilometragem currentKilometragem = await _kilimetragensRepository.GetKilometragemByIdAsync(id);
            if (currentKilometragem == null)
            {
                throw new NotFoundException("Not found");
            }

            currentKilometragem.Km = Kilometragem.Km;
            currentKilometragem.DiKilometragem = Kilometragem.DiKilometragem;
            await _unitOfWork.SaveChangesAsync();

            return Kilometragem;
        }

        public async Task RemoveKilometragem(int id)
        {
            Kilometragem currentKilometragem = await _kilimetragensRepository.GetKilometragemByIdAsync(id);
            await _kilimetragensRepository.RemoveKilometragem(currentKilometragem);
            await _unitOfWork.SaveChangesAsync();

            return;
        }
    }
}
