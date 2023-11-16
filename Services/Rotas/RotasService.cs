using RotaLimpa.Api.Exceptions;
using RotaLimpa.Api.Repositories.UnitOfWork;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories;
using RotaLimpa.Api.Repositories.Interfaces;

namespace RotaLimpa.Api.Services.Rotas
{
    public class RotasService : IRotasService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IRotasRepository _rotasRepository;

        public RotasService(IRotasRepository rotasRepository, IUnitOfWork unitOfWork)
        {
            _rotasRepository = rotasRepository;
            _unitOfWork = unitOfWork;
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
            Rota currentRota = await _rotasRepository.GetRotaByIdAsync(rota.Id);
            if (currentRota != null && currentRota.Equals(currentRota))
            {
                throw new Exception("Relatório final já existe.");
            }
            await _rotasRepository.CreateRotaAsync(rota);
            await _unitOfWork.SaveChangesAsync();
            return currentRota;
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
        public async Task<Rota> RemoveRota(int id, Rota rota)
        {
            Rota currentRota = await _rotasRepository.GetRotaByIdAsync(rota.Id);
            await _rotasRepository.RemoveRota(rota);
            await _unitOfWork.SaveChangesAsync();

            return rota;

        }
    }
}
