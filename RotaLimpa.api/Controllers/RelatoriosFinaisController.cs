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
        private readonly ITrajetosService _trajetosService;
        private readonly ISetoresService _setoresService;
        private readonly IOcorrenciasService _ocorrenciasService;

        public RelatoriosFinaisController(DataContext context, IRelatoriosFinaisService relatoriosFinaisService, ITrajetosService trajetosService, ISetoresService setoresService, IOcorrenciasService ocorrenciasService)
        {
            _context = context;
            _relatoriosFinaisService = relatoriosFinaisService;
            _trajetosService = trajetosService;
            _setoresService = setoresService;
            _ocorrenciasService = ocorrenciasService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<RelatorioFinal> lista = await _relatoriosFinaisService.GetAllRelatoriosFinaisAsync();
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

                Trajeto trajeto = await _trajetosService.GetTrajetoByIdAsync(novoRelatorioFinal.IdTrajeto);
                Setor setor = await _setoresService.GetSetorByIdAsync(novoRelatorioFinal.IdSetor);
                IEnumerable<Ocorrencia> listaOcorrencia = await _ocorrenciasService.GetAllOcorrenciaIdTrajetoAsync(trajeto.Id);

                var relatorio = new RelatorioFinal();
                relatorio.CriarPDF(novoRelatorioFinal, trajeto, setor, listaOcorrencia);

                return Ok(novoRelatorioFinal);
            }
            catch (System.Exception)
            {
                
                throw;
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
