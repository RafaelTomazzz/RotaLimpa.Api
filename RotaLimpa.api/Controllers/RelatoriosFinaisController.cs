using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Services;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RelatoriosFinaisController :ControllerBase
    {
        private readonly DataContext _context;
        private readonly IRelatoriosFinaisService _relatoriosFinaisService;

        public RelatoriosFinaisController(DataContext context, IRelatoriosFinaisService relatoriosFinaisService)
        {
            _context = context;
            _relatoriosFinaisService = relatoriosFinaisService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<RelatorioFinal> lista = await _relatoriosFinaisService.GetAllRelatoriosFinaisAsync();
                RelatorioFinal.CriarPDF();
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
                RelatorioFinal relatorioFinal = await _relatoriosFinaisService.GetRelatorioFinalByIdAsync(id);
                return Ok(relatorioFinal);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RelatorioFinal novoRelatorioFinal)
        {
            try
            {
                await _relatoriosFinaisService.CreateRelatorioFinalAsync(novoRelatorioFinal);
                RelatorioFinal.CriarPDF();

                return Ok(novoRelatorioFinal);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] RelatorioFinal relatorioFinalAlterado)
        {
            try
            {
                RelatorioFinal currentRelatorioFinal = await _relatoriosFinaisService.UpdateRelatorioFinalAsync(id, relatorioFinalAlterado);

                return Ok(currentRelatorioFinal);
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
                await _relatoriosFinaisService.RemoveRelatorioFinal(id);
                
                return Ok("Deletado com sucesso");
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
