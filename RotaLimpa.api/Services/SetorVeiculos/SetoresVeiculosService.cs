using RotaLimpa.Api.Exceptions;
using RotaLimpa.Api.Repositories.UnitOfWork;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories.Interfaces;
using RotaLimpa.Api.Repositories;
using System.Security.Cryptography;

namespace RotaLimpa.Api.Services
{
    public class SetoresVeiculosService : ISetoresVeiculosService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ISetoresVeiculosRepository _setorVeiculosRepository;

        private readonly ISetoresService _setoresService;

        private readonly IFrotasService _frotasService;

        public SetoresVeiculosService(ISetoresVeiculosRepository setorVeiculosRepository, IUnitOfWork unitOfWork, ISetoresService setoresService, IFrotasService frotasService)
        {
            _setorVeiculosRepository = setorVeiculosRepository;
            _unitOfWork = unitOfWork;
            _setoresService = setoresService;
            _frotasService = frotasService;
        }
        public async Task<IEnumerable<SetorVeiculo>> GetAllSetoresVeiculosAsync()
        {
            IEnumerable<SetorVeiculo> setorVeiculo = await _setorVeiculosRepository.GetAllSetoresVeiculosAsync();
            return setorVeiculo;
        }

        public async Task<SetorVeiculo> GetSetorVeiculoByIdAsync(int id)
        {
            SetorVeiculo setorVeiculo = await _setorVeiculosRepository.GetSetorVeiculoByIdAsync(id);
            if (setorVeiculo == null)
            {
                throw new NotFoundException("Not Found");
            }

            return setorVeiculo;
        }
        public  async Task<SetorVeiculo> CreateSetorVeiculoAsync(SetorVeiculo setorVeiculo)
        {
            Setor setor = await _setoresService.GetSetorByIdAsync(setorVeiculo.IdSetor);
            if (setor == null)
            {
                throw new Exception("Setor doesn't exists.");
            }

            Frota frota = await _frotasService.GetFrotaByIdAsync(setorVeiculo.IdFrota);
            if (frota == null)
            {
                throw new Exception("Frota doesn't exists.");
            }

            await _setorVeiculosRepository.CreateSetorVeiculoAsync(setorVeiculo);
            await _unitOfWork.SaveChangesAsync();
            return setorVeiculo;
        }
        public async Task<SetorVeiculo> UpdateSetorVeiculoAsync(int id, SetorVeiculo setorVeiculo)
        {
            SetorVeiculo currentSetorVeiculo = await _setorVeiculosRepository.GetSetorVeiculoByIdAsync(setorVeiculo.IdSetor);
            if (currentSetorVeiculo == null)
            {
                throw new NotFoundException("Not found");
            }
            currentSetorVeiculo.IdSetor = setorVeiculo.IdSetor;
            currentSetorVeiculo.IdFrota = setorVeiculo.IdFrota;

            await _unitOfWork.SaveChangesAsync();
            return setorVeiculo;
        }


        public  async Task RemoveSetorVeiculo(int id)
        {
            SetorVeiculo currentSetorVeiculo = await _setorVeiculosRepository.GetSetorVeiculoByIdAsync(id);
            await _setorVeiculosRepository.RemoveSetorVeiculo(currentSetorVeiculo);
            await _unitOfWork.SaveChangesAsync();

            return;
        }

        
    }
}
