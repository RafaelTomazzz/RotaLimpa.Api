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
    public class CEPsService : ICEPsService
    {
        private readonly IUnitOfWork _unitOfWor;

        private readonly ICEPsRepository _cepsRepository;

        public CEPsService(ICEPsRepository cepsRepository, IUnitOfWork unitOfWork)
        {
            _cepsRepository = cepsRepository;
            _unitOfWor = unitOfWork;
        }

        public async Task<IEnumerable<CEP>> GetAllCEPsAsync()
        {
            IEnumerable<CEP> ceps = await _cepsRepository.GetAllCEPsAsync();
            return ceps;
        }

        public async Task<CEP> GetCEPByIdAsync(int id)
        {
            CEP cep = await _cepsRepository.GetCEPByIdAsync(id);
            if (cep == null)
            {
                throw new NotFoundException("Not Found");
            }
            return cep;
        }

        public async Task<CEP> CreateCEPAsync(CEP cep)
        {
            CEP currentCEP = await _cepsRepository.GetCEPByIdAsync(cep.Id);
            if (currentCEP != null && currentCEP.Equals(cep))
            {
                throw new Exception("CEP already exists.");
            }
            await _cepsRepository.CreateCEPAsync(cep);
            await _unitOfWor.SaveChangesAsync();
            return currentCEP;
        }

        public async Task<CEP> UpdateCEPAsync(int id, CEP cep)
        {
            CEP currentCEP = await _cepsRepository.GetCEPByIdAsync(id);
            if (currentCEP == null)
            {
                throw new NotFoundException("Not found");
            }

            currentCEP.Cep = cep.Cep;
            currentCEP.Logradouro = cep.Logradouro;
            currentCEP.Endereco = cep.Endereco;
            currentCEP.Bairro = cep.Bairro;
            currentCEP.Cidade = cep.Cidade;
            currentCEP.UF = cep.UF;
            currentCEP.Latitude = cep.Latitude;
            currentCEP.Longitude = cep.Longitude;
            await _unitOfWor.SaveChangesAsync();

            return cep;
        }

        public async Task<CEP> RemoveCEP(int id, CEP cep)
        {
            CEP currentCEP = await _cepsRepository.GetCEPByIdAsync(id);
            await _cepsRepository.RemoveCEP(cep);
            await _unitOfWor.SaveChangesAsync();

            return cep;
        }
    }
}
