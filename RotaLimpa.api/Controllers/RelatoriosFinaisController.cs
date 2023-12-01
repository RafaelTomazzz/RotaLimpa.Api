using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Exceptions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Services;

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
                return Ok(lista);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
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
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RelatorioFinal novoRelatorioFinal)
        {
            try
            {
                await _relatoriosFinaisService.CreateRelatorioFinalAsync(novoRelatorioFinal);

                return Ok(novoRelatorioFinal);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RelatorioFinal relatorioFinalAlterado)
        {
            try
            {
                RelatorioFinal currentRelatorioFinal = await _relatoriosFinaisService.UpdateRelatorioFinalAsync(id, relatorioFinalAlterado);

                return Ok(currentRelatorioFinal);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
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
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }
    }
}
