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

        public KilometragensService(IKilometragensRepository kilimetragensRepository, IUnitOfWork unitOfWork)
        {
            _kilimetragensRepository = kilimetragensRepository;
            _unitOfWork = unitOfWork;
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
            Kilometragem currentKilometragem = await _kilimetragensRepository.GetKilometragemByIdAsync(Kilometragem.IdVeiculo);
            if (currentKilometragem != null && currentKilometragem.Equals(Kilometragem))
            {
                throw new Exception("Kilometragem already exists.");
            }
            await _kilimetragensRepository.CreateKilometragemAsync(Kilometragem);
            await _unitOfWork.SaveChangesAsync();
            return currentKilometragem;
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

        public async Task<Kilometragem> RemoveKilometragem(int id, Kilometragem kilometragem)
        {
            Kilometragem currentKilometragem = await _kilimetragensRepository.GetKilometragemByIdAsync(id);
            await _kilimetragensRepository.RemoveKilometragem(kilometragem);
            await _unitOfWork.SaveChangesAsync();

            return kilometragem;
        }
    }
}
