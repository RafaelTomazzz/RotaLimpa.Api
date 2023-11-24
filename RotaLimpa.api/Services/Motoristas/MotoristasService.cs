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

        public async Task<Motorista> CreateMotoristaAsync(Motorista novoMotorista)
        {
            Motorista currentMotorista = await _motoristasRepository.GetMotoristaByCPFAsync(novoMotorista.Cpf);
            if (currentMotorista != null && currentMotorista.Equals(novoMotorista))
            {
                throw new Exception("Motorista already exists.");
            }

            novoMotorista.Login = await GerarUnicoLoginAsync();

            await _motoristasRepository.CreateMotoristaAsync(novoMotorista);
            await _unitOfWork.SaveChangesAsync();
            return novoMotorista;
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

        public async Task RemoveMotorista(int id)
        {
            Motorista currentMotorista = await _motoristasRepository.GetMotoristaByIdAsync(id);
            await _motoristasRepository.RemoveMotorista(currentMotorista);
            await _unitOfWork.SaveChangesAsync();

            return;
        }

        public async Task<string> GerarUnicoLoginAsync()
        {
            DateTime currentYear = DateTime.Now;
            DateTime ultimaDate = await _motoristasRepository.BuscarUltimaCriacao();
            string login;

            if (currentYear.Year != ultimaDate.Year)
            {
                login = "001" + $"{DateTime.Now.ToString("MMyy")}";
                return login;
            }

            int ultimoSequencialLogin = await _motoristasRepository.ObterUltimoNumeroLoginAsync();

            if (ultimoSequencialLogin >= 999)
            {
                login = "001" + $"{DateTime.Now.ToString("MMyy")}";
                return login;
            }

            login = $"{ultimoSequencialLogin + 1:D3}" + $"{DateTime.Now.ToString("MMyy")}";
            return login;
        }

    }
}
