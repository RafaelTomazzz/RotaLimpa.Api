using RotaLimpa.Api.Exceptions;
using RotaLimpa.Api.Repositories.UnitOfWork;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories;
using RotaLimpa.Api.Repositories.Interfaces;

namespace RotaLimpa.Api.Services
{
    public class RotasService : IRotasService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IRotasRepository _rotasRepository;

        private readonly ISetoresService _setoresService;

        private readonly IColaboradoresService _colaboradoresService;

        public RotasService(IRotasRepository rotasRepository, IUnitOfWork unitOfWork, ISetoresService setoresService, IColaboradoresService colaboradoresService)
        {
            _rotasRepository = rotasRepository;
            _unitOfWork = unitOfWork;
            _setoresService = setoresService;
            _colaboradoresService = colaboradoresService;
        }
        public async Task<IEnumerable<Rota>> GetAllRotasAsync()
        {
            IEnumerable<Rota> rota = await _rotasRepository.GetAllRotasAsync();
            return rota;
        }
        public async Task<Rota> GetRotaByIdAsync(int id)
        {
            Rota rota = await _rotasRepository.GetRotaByIdAsync(id);
            if (rota == null)
            {
                throw new NotFoundException("Not Found");
            }

            return rota;
        }
        public async Task<Rota> CreateRotaAsync(Rota rota)
        {
            Setor setor = await _setoresService.GetSetorByIdAsync(rota.IdSetor);
            if (setor == null)
            {
                throw new Exception("Setor doesn't exists.");
            }

            Colaborador colaborador = await _colaboradoresService.GetColaboradorByIdAsync(rota.IdColaborador);
            if (colaborador == null)
            {
                throw new Exception("Colaborador doesn't exists.");
            }
            await _rotasRepository.CreateRotaAsync(rota);
            await _unitOfWork.SaveChangesAsync();
            return rota;
        }
        public async Task<Rota> UpdateRotaAsync(int id, Rota rota)
        {
            Rota currentRota = await _rotasRepository.GetRotaByIdAsync(rota.Id);
            if (currentRota == null)
            {
                throw new NotFoundException("Not found");
            }
            currentRota.IdSetor = rota.IdSetor;
            currentRota.IdColaborador = rota.IdColaborador;
            currentRota.DtRota = rota.DtRota;
            currentRota.TmRota = rota.TmRota;

             await _unitOfWork.SaveChangesAsync();
            return rota;
        }
        public async Task RemoveRota(int id)
        {
            Rota currentRota = await _rotasRepository.GetRotaByIdAsync(id);
            await _rotasRepository.RemoveRota(currentRota);
            await _unitOfWork.SaveChangesAsync();

            return;

        }
    }
}
