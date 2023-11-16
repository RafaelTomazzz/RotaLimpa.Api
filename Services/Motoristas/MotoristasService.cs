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
    public class MotoristasService : IMotoristasService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMotoristasRepository _motoristasRepository;

        public MotoristasService(IMotoristasRepository motoristasRepository, IUnitOfWork unitOfWork)
        {
            _motoristasRepository = motoristasRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Motorista>> GetAllMotoristasAsync()
        {
            IEnumerable<Motorista> motoristas = await _motoristasRepository.GetAllMotoristasAsync();
            return motoristas;
        }

        public async Task<Motorista> GetMotoristaByIdAsync(int id)
        {
            Motorista motorista = await _motoristasRepository.GetMotoristaByIdAsync(id);
            if (motorista == null)
            {
                throw new NotFoundException("Not Found");
            }
            return motorista;
        }

        public async Task<Motorista> CreateMotoristaAsync(Motorista motorista)
        {
            Motorista currentMotorista = await _motoristasRepository.GetMotoristaByIdAsync(motorista.Id);
            if (currentMotorista != null && currentMotorista.Equals(motorista))
            {
                throw new Exception("Motorista already exists.");
            }
            await _motoristasRepository.CreateMotoristaAsync(motorista);
            await _unitOfWork.SaveChangesAsync();
            return currentMotorista;
        }

        public async Task<Motorista> UpdateMotoristaAsync(int id, Motorista motorista)
        {
            Motorista currentMotorista = await _motoristasRepository.GetMotoristaByIdAsync(id);
            if (currentMotorista == null)
            {
                throw new NotFoundException("Not found");
            }

            currentMotorista.PNome = motorista.PNome;
            currentMotorista.SNome = motorista.SNome;
            currentMotorista.Di_Motorista = motorista.Di_Motorista;
            currentMotorista.StMotorista = motorista.StMotorista;
            currentMotorista.Cpf = motorista.Cpf;
            currentMotorista.Rg = motorista.Rg;
            currentMotorista.Senha = motorista.Senha;
            await _unitOfWork.SaveChangesAsync();

            return motorista;
        }

        public Task<Motorista> RemoveMotorista(int id, Motorista motorista)
        {
            throw new NotImplementedException();
        }

    }
}
