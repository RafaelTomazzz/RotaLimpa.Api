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
    public class EmpresasService : IEmpresasService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IEmpresasRepository _empresasRepository;

        public EmpresasService(IEmpresasRepository empresasRepository, IUnitOfWork unitOfWork)
        {
            _empresasRepository = empresasRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Empresa>> GetAllEmpresasAsync()
        {
            IEnumerable<Empresa> empresas = await _empresasRepository.GetAllEmpresasAsync();
            return empresas;
        }

        public async Task<Empresa> GetEmpresaByIdAsync(int id)
        {
            Empresa empresa = await _empresasRepository.GetEmpresaByIdAsync(id);
            if (empresa == null)
            {
                throw new NotFoundException("Not Found");
            }
            return empresa;
        }

        public async Task<Empresa> CreateEmpresaAsync(Empresa empresa)
        {
            Empresa currentEmpresa = await _empresasRepository.GetEmpresaByCNPJAsync(empresa.DcEmpresa);
            if (currentEmpresa != null && currentEmpresa.Equals(empresa))
            {
                throw new Exception("Empresa already exists.");
            }

            if (empresa.DcEmpresa == null || empresa.DcEmpresa == string.Empty)
            {
                throw new Exception("Need to informe the CNPJ's Empresa.");
            }
            await _empresasRepository.CreateEmpresaAsync(empresa);
            await _unitOfWork.SaveChangesAsync();
            return empresa;
        }

        public async Task<Empresa> UpdateEmpresaAsync(int id, Empresa empresa)
        {
            Empresa currentEmpresa = await _empresasRepository.GetEmpresaByIdAsync(id);
            if (currentEmpresa == null)
            {
                throw new NotFoundException("Not found");
            }

            currentEmpresa.Nome = empresa.Nome;
            currentEmpresa.DcEmpresa = empresa.DcEmpresa;
            currentEmpresa.StEmpresa = empresa.StEmpresa;
            currentEmpresa.DaEmpresa = DateTime.Now;
            await _unitOfWork.SaveChangesAsync();

            return empresa;
        }

        public async Task RemoveEmpresa(int id)
        {
            Empresa currentEmpresa = await _empresasRepository.GetEmpresaByIdAsync(id);
            await _empresasRepository.RemoveEmpresa(currentEmpresa);
            await _unitOfWork.SaveChangesAsync();

            return;
        }

    }
}
