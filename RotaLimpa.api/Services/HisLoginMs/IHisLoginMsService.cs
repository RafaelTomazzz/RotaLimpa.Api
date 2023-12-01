using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Services
{
    public interface IHisLoginMsService
    {
        public Task<IEnumerable<HisLoginM>> GetAllHisLoginMsAsync();

        public Task<HisLoginM> GetHisLoginMByIdAsync(int id);

        public Task<IEnumerable<HisLoginM>> GetAllHisLoginMsMotoristaAsync(int idMotorista);

        public Task<HisLoginM> CreateHisLoginMAsync(HisLoginM hisLoginM);

        public Task<HisLoginM> UpdateHisLoginMAsync(int id, HisLoginM hisLoginM);

        public Task RemoveHisLoginM(int id);
    }
}
