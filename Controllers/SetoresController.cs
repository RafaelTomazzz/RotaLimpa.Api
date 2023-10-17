using System;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Models.inputs;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SetoresController : ControllerBase
    {
        private readonly DataContext _context;

        public SetoresController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Setor> lista = await _context.Setores.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Setor s = await _context.Setores.FirstOrDefaultAsync(s => s.Id == id);
                return Ok(s);
                
            }
            catch (System.Exception ex)
            {
                return BadRequest (ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(SetorInput novosetor)
        {   
            try
            {
                await _context.Setores.AddAsync(novosetor);
                await _context.SaveChangesAsync();

                return Ok(novosetor);
            }
            catch (System.Exception ex)
            {
             
                return BadRequest(ex.Message);
            }
        }
    }
}