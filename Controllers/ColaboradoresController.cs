using System;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace RotaLimpa.Api.Controllers 
{
    [ApiController]
    [Route("[Controller]")]
    public class ColaboradoresController : ControllerBase
    {
        private readonly DataContext _context;

        public ColaboradoresController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Colaborador> lista = await _context.Colaboradores.ToListAsync();
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
                Colaborador c = await _context.Colaboradores.FirstOrDefaultAsync(c => c.Id == id);
                return Ok(c);
                
            }
            catch (System.Exception ex)
            {
                return BadRequest (ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Colaborador novocolaborador)
        {   
            try
            {
                await _context.Colaboradores.AddAsync (novocolaborador);
                await _context.SaveChangesAsync();

                return Ok(novocolaborador);
            }
            catch (System.Exception)
            {
             
                throw;
            }
        }
    }
}