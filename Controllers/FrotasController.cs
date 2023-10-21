using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FrotasController : ControllerBase
    {
        private readonly DataContext _context;

        public FrotasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Frota> lista = await _context.Frotas.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Frota frota = await _context.Frotas.FirstOrDefaultAsync(kBusca => kBusca.Id_Veiculo == id);
                if (frota != null)
                {
                    return Ok(frota);
                }
                return NotFound(); // Retorna 404 se a frota não for encontrada.
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Frota novaFrota)
        {
            try
            {
                await _context.Frotas.AddAsync(novaFrota);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetById", new { id = novaFrota.Id_Veiculo }, novaFrota);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Frota frotaAlterada)
        {
            try
            {
                _context.Entry(frotaAlterada).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(frotaAlterada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Frota frota = await _context.Frotas.FirstOrDefaultAsync(kBusca => kBusca.Id_Veiculo == id);

                if (frota != null)
                {
                    _context.Frotas.Remove(frota);
                    await _context.SaveChangesAsync();
                    return NoContent(); 
                }
                return NotFound(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
