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
    public class RuasController : ControllerBase
    {
        private readonly DataContext _context;

        public RuasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                var rua = await _context.Ruas.FirstOrDefaultAsync(b => b.Id == id);

                if (rua == null)
                {
                    return NotFound("Rua não encontrada.");
                }

                return Ok(rua);
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
                List<Rua> lista = await _context.Ruas.ToListAsync();

                if (lista.Count == 0)
                {
                    return NotFound("Nenhuma rua encontrada.");
                }

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("RegistrarRua")]
         public async Task<IActionResult> RegistrarRuaAsync([FromBody] Rua rua)
        {
            try
            {
                var existingRua = await _context.Ruas.FirstOrDefaultAsync(b => b.Id == rua.Id);

                if (existingRua != null)
                {
                    throw new Exception("Esta rua já existe.");
                }

                await _context.Ruas.AddAsync(rua);

                int linhaAfetadas = await _context.SaveChangesAsync();

                return Ok(linhaAfetadas);
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
                Rua rRua = await _context.Ruas
                    .FirstOrDefaultAsync(delete => delete.Id == id);

                _context.Ruas.Remove(rRua);
                int linhaAfetadas = await _context.SaveChangesAsync();

                return Ok(linhaAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}