using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Exceptions;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Services;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OcorrenciasController : ControllerBase
    {
         private readonly DataContext _context;

         private readonly IOcorrenciasService _ocorrenciasService;

        public OcorrenciasController(DataContext context, IOcorrenciasService ocorrenciasService)
        {
            _context = context;
            _ocorrenciasService = ocorrenciasService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Ocorrencia> lista = await _ocorrenciasService.GetAllOcorrenciasAsync();
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
                Ocorrencia ocorrencia = await _ocorrenciasService.GetOcorrenciaByIdAsync(id);
                return Ok(ocorrencia);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Ocorrencia novoOcorrencia)
        {
            try
            {
                await _ocorrenciasService.CreateOcorrenciaAsync(novoOcorrencia);

                return Ok(novoOcorrencia);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Ocorrencia ocorrenciaAlterado)
        {
            try
            {
                Ocorrencia currentOcorrencia = await _ocorrenciasService.UpdateOcorrenciaAsync(id, ocorrenciaAlterado);

                return Ok(currentOcorrencia);
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
                await _ocorrenciasService.RemoveOcorrencia(id);
                
                return Ok("Deletado com sucesso");
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }
    }
}