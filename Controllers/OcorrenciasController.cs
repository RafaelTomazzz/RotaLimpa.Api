using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OcorrenciasController : ControllerBase
    {
         private readonly DataContext _context;

        public OcorrenciasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Ocorrencia> lista = await _context.Ocorrencias.ToListAsync();
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
                Ocorrencia ocorrencia = await _context.Ocorrencias.FirstOrDefaultAsync(ocorreBusca => ocorreBusca.Id == id);
                return Ok(ocorrencia);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Ocorrencia novoOcorrencia)
        {
            try
            {
                await _context.Ocorrencias.AddAsync(novoOcorrencia);
                await _context.SaveChangesAsync();

                return Ok(novoOcorrencia);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Ocorrencia ocorrenciaAlterado)
        {
            try
            {
                _context.Ocorrencias.Update(ocorrenciaAlterado);
                await _context.SaveChangesAsync();

                return Ok(ocorrenciaAlterado);
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
                Ocorrencia ocorrencia = await _context.Ocorrencias.FirstOrDefaultAsync(ocorreBusca => ocorreBusca.Id == id);

                _context.Ocorrencias.Remove(ocorrencia);
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