using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Repositories.Interfaces
{
    public interface IHisLoginMsRepository
    {
        public Task<IEnumerable<HisLoginM>> GetAllHisLoginMsAsync();
        public Task<IEnumerable<HisLoginM>> GetAllHisLoginMsMotoristaAsync(int idMotorista);
        public Task<HisLoginM> GetHisLoginMByIdAsync(int id);
        public Task CreateHisLoginMAsync(HisLoginM hisLoginM);
        public Task RemoveHisLoginM(HisLoginM hisLoginM);
    }
}
