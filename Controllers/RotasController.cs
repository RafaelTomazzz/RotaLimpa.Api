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
    public class RotasController : ControllerBase
    {
        private readonly DataContext _context;

        public RotasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                var rota = await _context.Rotas.FirstOrDefaultAsync(b => b.IdRota == id);

                if (rota == null)
                {
                    return NotFound("Rota não encontrada.");
                }

                return Ok(rota);
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
                List<Rota> lista = await _context.Rotas.ToListAsync();

                if (lista.Count == 0)
                {
                    return NotFound("Nenhuma rota encontrada.");
                }

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("RegistrarRotas")]
        public async Task<IActionResult> RegistrarRotasAsync([FromBody] Rota rota)
        {
            try
            {
                await _context.Rotas.AddAsync(rota);
                int linhaAfetadas = await _context.SaveChangesAsync();

                return Ok(linhaAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Rota rotaAlterada)
        {   
            try
            {
                _context.Rotas.Update(rotaAlterada);
                await _context.SaveChangesAsync();

                return Ok(rotaAlterada);
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
                Rota rRota = await _context.Rotas
                    .FirstOrDefaultAsync(delete => delete.IdRota == id);

                _context.Rotas.Remove(rRota);
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