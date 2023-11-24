using System;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RotaLimpa.Api.Services;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class HisLoginMsController : ControllerBase
    {
         private readonly DataContext _context;

         private readonly IHisLoginMsService _hisLoginMsService;

        public HisLoginMsController(DataContext context, IHisLoginMsService hisLoginMsService)
        {
            _context = context;
            _hisLoginMsService = hisLoginMsService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<HisLoginM> lista = await _hisLoginMsService.GetAllHisLoginMsAsync();
                return Ok(lista);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                HisLoginM hisLoginM = await _hisLoginMsService.GetHisLoginMByIdAsync(id);
                return Ok(hisLoginM);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] HisLoginM novoHisLoginM)
        {
            try
            {
                await _hisLoginMsService.CreateHisLoginMAsync(novoHisLoginM);

                return Ok(novoHisLoginM);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HisLoginM hisLoginMAlterado)
        {
            try
            {
                HisLoginM currentHisLoginM = await _hisLoginMsService.UpdateHisLoginMAsync(id, hisLoginMAlterado);

                return Ok(currentHisLoginM);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _hisLoginMsService.RemoveHisLoginM(id);
                
                return Ok("Deletado com sucesso");
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}