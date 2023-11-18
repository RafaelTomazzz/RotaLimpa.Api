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
    public class HisLoginMsService : IHisLoginMsService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IHisLoginMsRepository _hisLoginMsRepository;

        public HisLoginMsService(IHisLoginMsRepository hisLoginMsRepository, IUnitOfWork unitOfWork)
        {
            _hisLoginMsRepository = hisLoginMsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<HisLoginM>> GetAllHisLoginMsAsync()
        {
            IEnumerable<HisLoginM> hisLoginMs = await _hisLoginMsRepository.GetAllHisLoginMsAsync();
            return hisLoginMs;
        }

        public async Task<HisLoginM> GetHisLoginMByIdAsync(int id)
        {
            HisLoginM hisLoginM = await _hisLoginMsRepository.GetHisLoginMByIdAsync(id);
            if (hisLoginM == null)
            {
                throw new NotFoundException("Not Found");
            }
            return hisLoginM;
        }

        public async Task<HisLoginM> CreateHisLoginMAsync(HisLoginM hisLoginM)
        {
            HisLoginM currentHisLoginM = await _hisLoginMsRepository.GetHisLoginMByIdAsync(hisLoginM.Id);
            if (currentHisLoginM != null && currentHisLoginM.Equals(hisLoginM))
            {
                throw new Exception("HisLoginM already exists.");
            }
            await _hisLoginMsRepository.CreateHisLoginMAsync(hisLoginM);
            await _unitOfWork.SaveChangesAsync();
            return currentHisLoginM;
        }

        public async Task<HisLoginM> UpdateHisLoginMAsync(int id, HisLoginM hisLoginM)
        {
            HisLoginM currentHisLoginM = await _hisLoginMsRepository.GetHisLoginMByIdAsync(id);
            if (currentHisLoginM == null)
            {
                throw new NotFoundException("Not found");
            }

            currentHisLoginM.IdMotorista = hisLoginM.IdMotorista;
            await _unitOfWork.SaveChangesAsync();

            return hisLoginM;
        }

        public async Task<HisLoginM> RemoveHisLoginM(int id, HisLoginM hisLoginM)
        {
            HisLoginM currentHisLoginM = await _hisLoginMsRepository.GetHisLoginMByIdAsync(id);
            await _hisLoginMsRepository.RemoveHisLoginM(hisLoginM);
            await _unitOfWork.SaveChangesAsync();

            return hisLoginM;
        }

    }
}
