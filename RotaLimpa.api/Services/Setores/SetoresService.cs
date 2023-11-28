using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories.Interfaces;
using RotaLimpa.Api.Repositories.UnitOfWork;
using RotaLimpa.Api.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace RotaLimpa.Api.Services
{
    public class SetoresService : ISetoresService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ISetoresRepository _setoresRepository;

        private readonly IEmpresasService _empresasService;

        private readonly IColaboradoresService _colaboradoresService;

        public SetoresService(ISetoresRepository setoresRepository, IUnitOfWork unitOfWork, IEmpresasService empresasService, IColaboradoresService colaboradoresService)
        {
            _setoresRepository = setoresRepository;
            _unitOfWork = unitOfWork;
            _empresasService = empresasService;
            _colaboradoresService = colaboradoresService;
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
            Empresa empresa = await _empresasService.GetEmpresaByIdAsync(setor.IdEmpresa);
            if (empresa == null)
            {
                throw new Exception("Empresa doesn't exists.");
            }

            Colaborador colaborador = await _colaboradoresService.GetColaboradorByIdAsync(setor.IdColaborador);
            if (colaborador == null)
            {
                throw new Exception("Colaborador doesn't exists.");
            }

            await _setoresRepository.CreateSetorAsync(setor);
            await _unitOfWork.SaveChangesAsync();
            return setor;
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

        public async Task RemoveSetor(int id)
        {
            Setor currentSetor = await _setoresRepository.GetSetorByIdAsync(id);
            await _setoresRepository.RemoveSetor(currentSetor);
            await _unitOfWork.SaveChangesAsync();

            return;
        }

    }
}
