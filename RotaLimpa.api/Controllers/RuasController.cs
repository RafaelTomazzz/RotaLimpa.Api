using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Services;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RuasController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IRuasService _ruasService; 

        public RuasController(DataContext context, IRuasService ruasService)
        {
            _context = context;
            _ruasService = ruasService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Rua> lista = await _ruasService.GetAllRuasAsync();
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
                Rua rua = await _ruasService.GetRuaByIdAsync(id);
                return Ok(rua);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Rua novoRua)
        {
            try
            {
                await _ruasService.CreateRuaAsync(novoRua);

                return Ok(novoRua);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Rua ruaAlterado)
        {
            try
            {
                Rua currentRua = await _ruasService.UpdateRuaAsync(id, ruaAlterado);

                return Ok(currentRua);
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
                await _ruasService.RemoveRua(id);
                
                return Ok("Deletado com sucesso");
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
