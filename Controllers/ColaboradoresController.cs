using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ColaboradoresController : ControllerBase
    {
        private readonly DataContext _context;

        public ColaboradoresController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                List<Colaborador> lista = await _context.Colaboradores.ToListAsync();
                // return Ok(lista);
                return Ok(lista);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        /*[HttpPost]
        public async Task<IActionResult> Post(Colaborador novoColaborador)
        {   
            try
            {
                await _context.Colaboradores.AddAsync (novoColaborador);
                await _context.SaveChangesAsync();

                return Ok(novoColaborador);
            }
            catch (System.Exception)
            {
             
                throw;
            }
        }
*/
        [HttpPost]
        public async Task<IActionResult> PostColaborador([FromBody] Colaborador colaborador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Colaboradores.Add(colaborador);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetColaborador", new { id = colaborador.Id }, colaborador);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}