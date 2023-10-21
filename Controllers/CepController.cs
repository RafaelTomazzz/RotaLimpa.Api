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
    public class CEPController : ControllerBase
    {
        private readonly DataContext _context;

        public CEPController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<CEP> lista = await _context.Ceps.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpGet("GetByCep/{cep}")]
        public async Task<IActionResult> GetByCep(string cep)
        {
            try
            {
                CEP cepInfo = await _context.Ceps.FirstOrDefaultAsync(c => c.Cep == cep);
                if (cepInfo != null)
                {
                    return Ok(cepInfo);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(CEP novoCEP)
        {
            try
            {
                await _context.Ceps.AddAsync(novoCEP);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetByCep", new { cep = novoCEP.Cep }, novoCEP);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(CEP cepAlterado)
        {
            try
            {
                _context.Entry(cepAlterado).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(cepAlterado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpDelete("{cep}")]
        public async Task<IActionResult> Delete(string cep)
        {
            try
            {
                CEP cepInfo = await _context.Ceps.FirstOrDefaultAsync(c => c.Cep == cep);

                if (cepInfo != null)
                {
                    _context.Ceps.Remove(cepInfo);
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
