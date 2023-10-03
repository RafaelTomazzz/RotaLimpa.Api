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
    public class ColaboaboradoresController : ControllerBase
    {
        private readonly DataContext _context;

        public ColaboaboradoresController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAsynzc()
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

        [HttpPost]
        public async Task<IActionResult> Post(Colaborador novocolaborador)
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