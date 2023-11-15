using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RelatoriosFinaisController :ControllerBase
    {
        private readonly DataContext _context;

        public RelatoriosFinaisController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<RelatorioFinal> lista = await _context.RelatoriosFinais.ToListAsync();
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
                RelatorioFinal relatorioFinal = await _context.RelatoriosFinais.FirstOrDefaultAsync(relatoriobusca => relatoriobusca.IdRelatorio == id);
                return Ok(relatorioFinal);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(RelatorioFinal novoRelatorioFinal)
        {
            try
            {
                await _context.RelatoriosFinais.AddAsync(novoRelatorioFinal);
                await _context.SaveChangesAsync();

                return Ok(novoRelatorioFinal);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(RelatorioFinal relatorioFinalAlterado)
        {
            try
            {
                _context.RelatoriosFinais.Update(relatorioFinalAlterado);
                await _context.SaveChangesAsync();

                return Ok(relatorioFinalAlterado);
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
                RelatorioFinal relatorioFinal = await _context.RelatoriosFinais.FirstOrDefaultAsync(relatoriobusca => relatoriobusca.IdRelatorio == id);

                _context.RelatoriosFinais.Remove(relatorioFinal);
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
