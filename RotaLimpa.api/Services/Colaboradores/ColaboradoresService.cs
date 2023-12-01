using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories.Interfaces;
using RotaLimpa.Api.Repositories.UnitOfWork;
using RotaLimpa.Api.Exceptions;
using RotaLimpa.Api.Repositories;

namespace RotaLimpa.Api.Services
{
    public class ColaboradoresService : IColaboradoresService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IColaboradoresRepository _colaboradoresRepository;

        private readonly IEmpresasService _empresasService;

        public ColaboradoresService(IColaboradoresRepository colaboradoresRepository, IUnitOfWork unitOfWork, IEmpresasService empresasService)
        {
            _colaboradoresRepository = colaboradoresRepository;
            _unitOfWork = unitOfWork;
            _empresasService = empresasService;
        }

        public async Task<IEnumerable<Colaborador>> GetAllColaboradoresAsync()
        {
            IEnumerable<Colaborador> colaboradores = await _colaboradoresRepository.GetAllColaboradoresAsync();

            if (colaboradores == null)
            {
                throw new NotFoundException("Ther isn't a colaborador.");
            }

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
            Colaborador currentColaborador = await _colaboradoresRepository.GetColaboradorByCPFAsync(colaborador.Cpf);
            if (currentColaborador != null)
            {
                throw new Exception("Colaborador already exists.");
            }

            Empresa empresa = await _empresasService.GetEmpresaByIdAsync(colaborador.IdEmpresa);
            if (empresa == null)
            {
                throw new Exception("Empresa doesn't exists.");
            }

            if (string.IsNullOrEmpty(colaborador.Cpf))
            {
                throw new Exception("Need to informe the CPF's Colaborador.");
            }

            colaborador.Login = await GerarUnicoLoginAsync();
            

            await _colaboradoresRepository.CreateColaboradorAsync(colaborador);
            await _unitOfWork.SaveChangesAsync();
            return colaborador;
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

        public async Task RemoveColaborador(int id)
        {
            Colaborador currentColaborador = await _colaboradoresRepository.GetColaboradorByIdAsync(id);
            await _colaboradoresRepository.RemoveColaborador(currentColaborador);
            await _unitOfWork.SaveChangesAsync();

            return;
        }

        private async Task<string> GerarUnicoLoginAsync()
        {
            DateTime currentYear = DateTime.Now;
            DateTime ultimaDate = await _colaboradoresRepository.BuscarUltimaCriacao();
            string login;

            if (ultimaDate == null) 
            {
                ultimaDate = DateTime.Now;
            }

            if (currentYear.Year != ultimaDate.Year)
            {
                login = "001" + $"{DateTime.Now.ToString("MMyy")}";
                return login;
            }

            int ultimoSequencialLogin = await _colaboradoresRepository.ObterUltimoNumeroLoginAsync();

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
