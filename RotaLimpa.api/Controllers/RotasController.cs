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
    public class RotasController : ControllerBase
    {
        private readonly DataContext _context;

        private readonly IRotasService _rotasService;

        public RotasController(DataContext context, IRotasService rotasService)
        {
            _context = context;
            _rotasService = rotasService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Rota> lista = await _rotasService.GetAllRotasAsync();
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
                Rota rota = await _rotasService.GetRotaByIdAsync(id);
                return Ok(rota);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Rota novoRota)
        {
            try
            {
                await _rotasService.CreateRotaAsync(novoRota);

                return Ok(novoRota);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Rota rotaAlterado)
        {
            try
            {
                Rota currentRota = await _rotasService.UpdateRotaAsync(id, rotaAlterado);

                return Ok(currentRota);
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
                await _rotasService.RemoveRota(id);
                
                return Ok("Deletado com sucesso");
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
