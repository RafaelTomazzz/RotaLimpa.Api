using System;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Exceptions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RotaLimpa.Api.Services;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class HisLoginCsController : ControllerBase
    {
         private readonly DataContext _context;

         private readonly IHisLoginCsService _hisLoginCsService;

        public HisLoginCsController(DataContext context, IHisLoginCsService hisLoginCsService)
        {
            _context = context;
            _hisLoginCsService = hisLoginCsService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<HisLoginC> lista = await _hisLoginCsService.GetAllHisLoginCsAsync();
                return Ok(lista);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                HisLoginC hisLoginC = await _hisLoginCsService.GetHisLoginCByIdAsync(id);
                return Ok(hisLoginC);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpGet("HistoricoColaborador/{id}")]
        public async Task<IActionResult> GetAllHisLoginCsColaborador(int idColaborador)
        {
            try
            {
                IEnumerable<HisLoginC> lista = await _hisLoginCsService.GetAllHisLoginCsColaboradorAsync(idColaborador);
                return Ok(lista);
            }
            catch (BaseException ex)
            {

                return ex.GetResponse();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] HisLoginC novoHisLoginC)
        {
            try
            {
                await _hisLoginCsService.CreateHisLoginCAsync(novoHisLoginC);

                return Ok(novoHisLoginC);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HisLoginC hisLoginCAlterado)
        {
            try
            {
                HisLoginC currentHisLoginC = await _hisLoginCsService.UpdateHisLoginCAsync(id, hisLoginCAlterado);

                return Ok(currentHisLoginC);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _hisLoginCsService.RemoveHisLoginC(id);
                
                return Ok("Deletado com sucesso");
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }
    }
}