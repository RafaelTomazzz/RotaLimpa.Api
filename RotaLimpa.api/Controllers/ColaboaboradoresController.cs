using System;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Services;

namespace RotaLimpa.Api.Controllers 
{
    [ApiController]
    [Route("[Controller]")]
    public class ColaboaboradoresController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IColaboradoresService _colaboradoresService;

        public ColaboaboradoresController(DataContext context, IColaboradoresService colaboradoresService)
        {
            _context = context;
            _colaboradoresService = colaboradoresService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Colaborador> lista = await _colaboradoresService.GetAllColaboradoresAsync();
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
                Colaborador colaborador = await _colaboradoresService.GetColaboradorByIdAsync(id);
                return Ok(colaborador);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Colaborador novoColaborador)
        {
            try
            {
                //novoColaborador.Login = await _colaboradoresService.GerarUnicoLoginAsync();
                await _colaboradoresService.CreateColaboradorAsync(novoColaborador);

                return Ok(novoColaborador);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut]
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

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Colaborador colaborador = await _colaboradoresService.GetColaboradorByIdAsync(id);

                await _colaboradoresService.RemoveColaborador(id, colaborador);
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