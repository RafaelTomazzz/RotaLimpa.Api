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
    public class OcorrenciasController : ControllerBase
    {
        private readonly DataContext _context;

        public OcorrenciasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                var ocorrencia = await _context.Ocorrencias.FirstOrDefaultAsync(b => b.IdOcorrencia == id);

                if (ocorrencia == null)
                {
                    return NotFound("Ocorrencia não encontrada.");
                }

                return Ok(ocorrencia);
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
                List<Ocorrencia> lista = await _context.Ocorrencias.ToListAsync();

                if (lista.Count == 0)
                {
                    return NotFound("Nenhuma ocorrencia encontrada.");
                }

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("RegistrarOcorrencia")]
        public async Task<IActionResult> RegistrarOcorrenciaAsync([FromBody] Ocorrencia ocorrencia)
        {
            try
            {

                await _context.Ocorrencias.AddAsync(ocorrencia);
                int linhaAfetadas = await _context.SaveChangesAsync();

                return Ok(linhaAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

         [HttpPut]
        public async Task<IActionResult> Update(Ocorrencia ocorrenciaAlterada)
        {   
            try
            {
                _context.Ocorrencias.Update(ocorrenciaAlterada);
                await _context.SaveChangesAsync();

                return Ok(ocorrenciaAlterada);
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
                Ocorrencia rOcorrencia = await _context.Ocorrencias
                    .FirstOrDefaultAsync(delete => delete.IdOcorrencia == id);

                _context.Ocorrencias.Remove(rOcorrencia);
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