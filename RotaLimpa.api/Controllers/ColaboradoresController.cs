using System;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Services;
using RotaLimpa.Api.DTO;

namespace RotaLimpa.Api.Controllers 
{
    [ApiController]
    [Route("[Controller]")]
    public class ColaboradoresController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IColaboradoresService _colaboradoresService;

        public ColaboradoresController(DataContext context, IColaboradoresService colaboradoresService)
        {
            _context = context;
            _colaboradoresService = colaboradoresService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Colaborador> colaborador = await _colaboradoresService.GetAllColaboradoresAsync();
                IEnumerable<ColaboradorDTO> colaboradorDTO = colaborador.Select(c => c.ToColaborador()); 
                return Ok(colaboradorDTO);
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
                Colaborador colaborador = await _colaboradoresService.GetColaboradorByIdAsync(id);
                ColaboradorDTO colaboradorDTO = colaborador.ToColaborador();
                return Ok(colaboradorDTO);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Colaborador novoColaborador)
        {
            try
            {
                await _colaboradoresService.CreateColaboradorAsync(novoColaborador);

                return Ok(novoColaborador.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Colaborador colaboradorAlterado)
        {
            try
            {
                Colaborador currentColaborador = await _colaboradoresService.UpdateColaboradorAsync(id, colaboradorAlterado);

                return Ok(currentColaborador);
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
                await _colaboradoresService.RemoveColaborador(id);
                
                return Ok("Deletado com sucesso");
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}