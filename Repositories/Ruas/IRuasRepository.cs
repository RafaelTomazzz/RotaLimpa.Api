﻿using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Repositories.Interfaces
{
    public interface IRuasRepository
    {
        public Task<List<Rua>> GetAllRuasAsync();
        public Task<Rua> GetRuaByIdAsync(int id);
        public Task CreateRuaAsync(Rua rua);
        public Task RemoveRua(Rua rua);
    }
}
