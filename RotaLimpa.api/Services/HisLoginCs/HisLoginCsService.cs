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
    public class HisLoginCsService : IHisLoginCsService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IHisLoginCsRepository _hisLoginCsRepository;

        private readonly IColaboradoresService _colaboradoresService;

        public HisLoginCsService(IHisLoginCsRepository hisLoginCsRepository, IUnitOfWork unitOfWork, IColaboradoresService colaboradoresService)
        {
            _hisLoginCsRepository = hisLoginCsRepository;
            _unitOfWork = unitOfWork;
            _colaboradoresService = colaboradoresService;
        }

        public async Task<IEnumerable<HisLoginC>> GetAllHisLoginCsAsync()
        {
            IEnumerable<HisLoginC> hisLoginCs = await _hisLoginCsRepository.GetAllHisLoginCsAsync();
            return hisLoginCs;
        }

        public async Task<IEnumerable<HisLoginC>> GetAllHisLoginCsColaboradorAsync(int idColaborador)
        {
            Colaborador colaborador = await _colaboradoresService.GetColaboradorByIdAsync(idColaborador);
            if (colaborador == null)
            {
                throw new Exception("Colaborador doesn't exists.");
            }
            IEnumerable<HisLoginC> hisLoginCsColaborador = await _hisLoginCsRepository.GetAllHisLoginCsColaboradorAsync(colaborador.Id);
            return hisLoginCsColaborador;
        }

        public async Task<HisLoginC> GetHisLoginCByIdAsync(int id)
        {
            HisLoginC hisLoginC = await _hisLoginCsRepository.GetHisLoginCByIdAsync(id);
            if (hisLoginC == null)
            {
                throw new NotFoundException("Not Found");
            }
            return hisLoginC;
        }

        public async Task<HisLoginC> CreateHisLoginCAsync(HisLoginC hisLoginC)
        {
            Colaborador colaborador = await _colaboradoresService.GetColaboradorByIdAsync(hisLoginC.IdColaborador);
            if (colaborador == null)
            {
                throw new Exception("Colaborador doesn't exists.");
            }

            await _hisLoginCsRepository.CreateHisLoginCAsync(hisLoginC);
            await _unitOfWork.SaveChangesAsync();
            return hisLoginC;
        }

        public async Task<HisLoginC> UpdateHisLoginCAsync(int id, HisLoginC hisLoginC)
        {
            HisLoginC currentHisLoginC = await _hisLoginCsRepository.GetHisLoginCByIdAsync(id);
            if (currentHisLoginC == null)
            {
                throw new NotFoundException("Not found");
            }

            currentHisLoginC.IdColaborador = hisLoginC.IdColaborador;
            await _unitOfWork.SaveChangesAsync();

            return hisLoginC;
        }

        public async Task RemoveHisLoginC(int id)
        {
            HisLoginC currentHisLoginC = await _hisLoginCsRepository.GetHisLoginCByIdAsync(id);
            await _hisLoginCsRepository.RemoveHisLoginC(currentHisLoginC);
            await _unitOfWork.SaveChangesAsync();

            return;
        }
    }
}
