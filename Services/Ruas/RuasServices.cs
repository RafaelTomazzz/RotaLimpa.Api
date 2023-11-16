﻿using RotaLimpa.Api.Exceptions;
using RotaLimpa.Api.Repositories.UnitOfWork;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories;
using RotaLimpa.Api.Repositories.Interfaces;

namespace RotaLimpa.Api.Services.Ruas
{
    public class RuasServices : IRuasServices
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IRuasRepository _ruasRepository;

        public RuasServices(IRuasRepository ruasRepository, IUnitOfWork unitOfWork)
        {
            _ruasRepository = ruasRepository;
            _unitOfWork = unitOfWork;
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
            Rua currentRua = await _ruasRepository.GetRuaByIdAsync(rua.Id);
            if (currentRua != null && currentRua.Equals(currentRua))
            {
                throw new Exception("Relatório final já existe.");
            }
            await _ruasRepository.CreateRuaAsync(rua);
            await _unitOfWork.SaveChangesAsync();
            return currentRua;
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
        public async Task<Rua> RemoveRua(int id, Rua rua)
        {
            Rua currentRota = await _ruasRepository.GetRuaByIdAsync(rua.Id);
            await _ruasRepository.RemoveRua(rua);
            await _unitOfWork.SaveChangesAsync();

            return rua;

        }
    }
}