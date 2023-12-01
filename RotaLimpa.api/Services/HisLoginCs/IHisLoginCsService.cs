using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Services
{
    public interface IHisLoginCsService
    {
        public Task<IEnumerable<HisLoginC>> GetAllHisLoginCsAsync();

        public Task<HisLoginC> GetHisLoginCByIdAsync(int id);

        public Task<IEnumerable<HisLoginC>> GetAllHisLoginCsColaboradorAsync(int idColaborador);

        public Task<HisLoginC> CreateHisLoginCAsync(HisLoginC hisLoginC);

        public Task<HisLoginC> UpdateHisLoginCAsync(int id, HisLoginC hisLoginC);

        public Task RemoveHisLoginC(int id);
    }
}
