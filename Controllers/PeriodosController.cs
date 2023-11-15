using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PeriodosController : ControllerBase
    {
        private readonly DataContext _context;

        public PeriodosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Periodo> lista = await _context.Periodos.ToListAsync();
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
                Periodo periodo = await _context.Periodos.FirstOrDefaultAsync(motoriBusca => motoriBusca.Id == id);
                return Ok(periodo);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Periodo novoPeriodo)
        {
            try
            {
                await _context.Periodos.AddAsync(novoPeriodo);
                await _context.SaveChangesAsync();

                return Ok(novoPeriodo);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Periodo periodoAlterado)
        {
            try
            {
                _context.Periodos.Update(periodoAlterado);
                await _context.SaveChangesAsync();

                return Ok(periodoAlterado);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Periodo periodo = await _context.Periodos.FirstOrDefaultAsync(periodobusca => periodobusca.Id == id);

                _context.Periodos.Remove(periodo);
                int linhaAfetada = await _context.SaveChangesAsync();

                return Ok(linhaAfetada);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
