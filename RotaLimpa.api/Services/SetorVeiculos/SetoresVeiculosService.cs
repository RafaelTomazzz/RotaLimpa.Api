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

        public SetoresVeiculosService(ISetoresVeiculosRepository setorVeiculosRepository, IUnitOfWork unitOfWork)
        {
            _setorVeiculosRepository = setorVeiculosRepository;
            _unitOfWork = unitOfWork;
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
            SetorVeiculo currentSetorVeiculo = await _setorVeiculosRepository.GetSetorVeiculoByIdAsync(setorVeiculo.IdSetor);
            if (currentSetorVeiculo != null && currentSetorVeiculo.Equals(currentSetorVeiculo))
            {
                throw new Exception("Relatório final já existe.");
            }
            await _setorVeiculosRepository.CreateSetorVeiculoAsync(setorVeiculo);
            await _unitOfWork.SaveChangesAsync();
            return currentSetorVeiculo;
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
