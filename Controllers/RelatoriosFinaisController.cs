﻿using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
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

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                RelatorioFinal relatorioFinal = await _relatoriosFinaisService.GetRelatorioFinalByIdAsync(id);

                await _relatoriosFinaisService.RemoveRelatorioFinal(id, relatorioFinal);
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
