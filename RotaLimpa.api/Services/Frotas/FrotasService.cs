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
    public class SetoresService : ISetoresService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ISetoresRepository _setoresRepository;

        public SetoresService(ISetoresRepository setoresRepository, IUnitOfWork unitOfWork)
        {
            _setoresRepository = setoresRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Setor>> GetAllSetoresAsync()
        {
            IEnumerable<Setor> setores = await _setoresRepository.GetAllSetoresAsync();
            return setores;
        }

        public async Task<Setor> GetSetorByIdAsync(int id)
        {
            Setor setor = await _setoresRepository.GetSetorByIdAsync(id);
            if (setor == null)
            {
                throw new NotFoundException("Not Found");
            }
            return setor;
        }

        public async Task<Setor> CreateSetorAsync(Setor setor)
        {
            Setor currentSetor = await _setoresRepository.GetSetorByIdAsync(setor.Id);
            if (currentSetor != null && currentSetor.Equals(setor))
            {
                throw new Exception("Setor already exists.");
            }
            await _setoresRepository.CreateSetorAsync(setor);
            await _unitOfWork.SaveChangesAsync();
            return currentSetor;
        }

        public async Task<Setor> UpdateSetorAsync(int id, Setor setor)
        {
            Setor currentSetor = await _setoresRepository.GetSetorByIdAsync(id);
            if (currentSetor == null)
            {
                throw new NotFoundException("Not found");
            }

            currentSetor.IdColaborador = setor.IdColaborador;
            currentSetor.IdEmpresa = setor.IdEmpresa;
            currentSetor.DaSetor = DateTime.Now;
            currentSetor.StSetor = setor.StSetor;
            await _unitOfWork.SaveChangesAsync();

            return setor;
        }

        public async Task<Setor> RemoveSetor(int id, Setor setor)
        {
            Setor currentSetor = await _setoresRepository.GetSetorByIdAsync(id);
            await _setoresRepository.RemoveSetor(setor);
            await _unitOfWork.SaveChangesAsync();

            return setor;
        }

    }
}
