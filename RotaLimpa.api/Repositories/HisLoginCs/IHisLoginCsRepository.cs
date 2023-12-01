using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Repositories.Interfaces
{
    public interface IHisLoginCsRepository
    {
        public Task<IEnumerable<HisLoginC>> GetAllHisLoginCsAsync();
        public Task<IEnumerable<HisLoginC>> GetAllHisLoginCsColaboradorAsync(int idColaborador);
        public Task<HisLoginC> GetHisLoginCByIdAsync(int id);
        public Task CreateHisLoginCAsync(HisLoginC hisLoginC);
        public Task RemoveHisLoginC(HisLoginC hisLoginC);
    }
}
