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
                Rota rota = await _context.Rotas
                    .FirstOrDefaultAsync(Busca => Busca.Id == id);

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
                // Aqui você pode adicionar lógica para salvar a rua no seu banco de dados.

                await _context.Rotas.AddAsync(rota);
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
                Rota rRota = await _context.Rotas
                    .FirstOrDefaultAsync(delete => delete.Id == id);

                _context.Rotas.Remove(rRota);
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