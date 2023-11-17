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
    public class ColaboradoresService : IColaboradoresService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IColaboradoresRepository _colaboradoresRepository;

        public ColaboradoresService(IColaboradoresRepository colaboradoresRepository, IUnitOfWork unitOfWork)
        {
            _colaboradoresRepository = colaboradoresRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Colaborador>> GetAllColaboradoresAsync()
        {
            IEnumerable<Colaborador> colaboradores = await _colaboradoresRepository.GetAllColaboradoresAsync();
            return colaboradores;
        }

        public async Task<Colaborador> GetColaboradorByIdAsync(int id)
        {
            Colaborador colaborador = await _colaboradoresRepository.GetColaboradorByIdAsync(id);
            if (colaborador == null)
            {
                throw new NotFoundException("Not Found");
            }
            return colaborador;
        }

        public async Task<Colaborador> CreateColaboradorAsync(Colaborador colaborador)
        {
            Colaborador currentColaborador = await _colaboradoresRepository.GetColaboradorByIdAsync(colaborador.Id);
            if (currentColaborador != null && currentColaborador.Equals(colaborador))
            {
                throw new Exception("Colaborador already exists.");
            }
            await _colaboradoresRepository.CreateColaboradorAsync(colaborador);
            await _unitOfWork.SaveChangesAsync();
            return currentColaborador;
        }

        public async Task<Colaborador> UpdateColaboradorAsync(int id, Colaborador colaborador)
        {
            Colaborador currentColaborador = await _colaboradoresRepository.GetColaboradorByIdAsync(id);
            if (currentColaborador == null)
            {
                throw new NotFoundException("Not found");
            }

            currentColaborador.PNome = colaborador.PNome;
            currentColaborador.SNome = colaborador.SNome;
            currentColaborador.Di_Colaborador = colaborador.Di_Colaborador;
            currentColaborador.StColaborador = colaborador.StColaborador;
            currentColaborador.Cpf = colaborador.Cpf;
            currentColaborador.Rg = colaborador.Rg;
            currentColaborador.Senha = colaborador.Senha;
            await _unitOfWork.SaveChangesAsync();

            return colaborador;
        }

        public async Task<Colaborador> RemoveColaborador(int id, Colaborador colaborador)
        {
            Colaborador currentColaborador = await _colaboradoresRepository.GetColaboradorByIdAsync(id);
            await _colaboradoresRepository.RemoveColaborador(colaborador);
            await _unitOfWork.SaveChangesAsync();

            return colaborador;
        }

        public async Task<string> GerarUnicoLoginAsync()
        {
            int currentYear = DateTime.Now.Year;
            int ultimoNumeroLogin = await _colaboradoresRepository.ObterUltimoNumeroLoginAsync(currentYear);

            if (!await ExisteMotoristaNoAnoAtualAsync(currentYear))
            {
                return $"1{DateTime.Now.ToString("MMyy")}";
            }

            if (ultimoNumeroLogin >= 999)
            {
                return $"1{DateTime.Now.ToString("MMyy")}";
            }

            return $"{ultimoNumeroLogin + 1:D3}{DateTime.Now.ToString("MMyy")}";
        }

        private async Task<bool> ExisteMotoristaNoAnoAtualAsync(int currentYear)
        {
            return await _colaboradoresRepository.ObterUltimoNumeroLoginAsync(currentYear) > 0;
        }

    }
}
