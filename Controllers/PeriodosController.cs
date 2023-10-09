using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace RotaLimpa.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class PeriodosController : ControllerBase
    {
        private readonly DataContext _context;

        public PeriodosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Periodo periodo = await _context.Periodos
                    .FirstOrDefaultAsync(Busca => Busca.Id_Periodo == id);

                return Ok(periodo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                List<Periodo> lista = await _context.Periodos.ToListAsync();
                
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Periodo rPeriodo = await _context.Periodos
                    .FirstOrDefaultAsync(delete => delete.Id_Periodo == id);

                _context.Periodos.Remove(rPeriodo);
                int linhaAfetadas = await _context.SaveChangesAsync();

                //Criar regra de negócio para lidar com o OK

                return Ok(linhaAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}