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
    public class PeriodosController : ControllerBase
    {
        private readonly DataContext _context;

        private readonly IPeriodosService _periodosService;

        public PeriodosController(DataContext context, IPeriodosService periodosService)
        {
            _context = context;
            _periodosService = periodosService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Periodo> lista = await _periodosService.GetAllPeriodosAsync();
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
                Periodo periodo = await _periodosService.GetPeriodoByIdAsync(id);
                return Ok(periodo);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Periodo novoPeriodo)
        {
            try
            {
                await _periodosService.CreatePeriodoAsync(novoPeriodo);

                return Ok(novoPeriodo);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Periodo periodoAlterado)
        {
            try
            {
                Periodo currentPeriodo = await _periodosService.UpdatePeriodoAsync(id, periodoAlterado);

                return Ok(currentPeriodo);
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
                await _periodosService.RemovePeriodo(id);
                
                return Ok("Deletado com sucesso");
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
