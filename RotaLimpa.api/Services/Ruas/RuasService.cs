using RotaLimpa.Api.Exceptions;
using RotaLimpa.Api.Repositories.UnitOfWork;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories;
using RotaLimpa.Api.Repositories.Interfaces;

namespace RotaLimpa.Api.Services
{
    public class RuasService : IRuasService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IRuasRepository _ruasRepository;

        private readonly ICEPsService _cepsService;

        private readonly IRotasService _rotasService;

        public RuasService(IRuasRepository ruasRepository, IUnitOfWork unitOfWork, ICEPsService cepsService, IRotasService rotasService)
        {
            _ruasRepository = ruasRepository;
            _unitOfWork = unitOfWork;
            _cepsService = cepsService;
            _rotasService = rotasService;
        }
        public async Task<IEnumerable<Rua>> GetAllRuasAsync()
        {
            IEnumerable<Rua> rua = await _ruasRepository.GetAllRuasAsync();
            return rua;
        }
        public async Task<Rua> GetRuaByIdAsync(int id)
        {
            Rua rua = await _ruasRepository.GetRuaByIdAsync(id);
            if (rua == null)
            {
                throw new NotFoundException("Not Found");
            }

            return rua;
        }
        public async Task<Rua> CreateRuaAsync(Rua rua)
        {
            Rota rota = await _rotasService.GetRotaByIdAsync(rua.IdRota);
            if (rota == null)
            {
                throw new Exception("Rota doesn't exists.");
            }

            CEP cep = await _cepsService.GetCEPByIdAsync(rua.IdCep);
            if (cep == null)
            {
                throw new Exception("CEP doesn't exists.");
            }

            await _ruasRepository.CreateRuaAsync(rua);
            await _unitOfWork.SaveChangesAsync();
            return rua;
        }
        public async Task<Rua> UpdateRuaAsync(int id, Rua rua)
        {
            Rua currentRua = await _ruasRepository.GetRuaByIdAsync(rua.Id);
            if (currentRua == null)
            {
                throw new NotFoundException("Not found");
            }
            currentRua.IdRota = rua.IdRota;
            currentRua.IdCep = rua.IdCep;

            await _unitOfWork.SaveChangesAsync();
            return rua;
        }
        public async Task RemoveRua(int id)
        {
            Rua currentRota = await _ruasRepository.GetRuaByIdAsync(id);
            await _ruasRepository.RemoveRua(currentRota);
            await _unitOfWork.SaveChangesAsync();

            return;

        }

        public async Task<IEnumerable<Rua>> GetAllRuasWhereRota(int idrota)
        {
            IEnumerable<Rua> ruas = await _ruasRepository.GetAllRuaWhereRotaAsync(idrota);
            return ruas;
        }
    }
}
