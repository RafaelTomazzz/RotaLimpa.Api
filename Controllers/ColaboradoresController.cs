using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                List<Colaboradores> lista = await _context.Colaboradores.ToListAsync();
                // return Ok(lista);
                return Ok(lista);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Colaboradores novoColaborador)
        {   
            try
            {
                await _context.Colaboradores.AddAsync (novoColaborador);
                await _context.SaveChangesAsync();

                return Ok(novoColaborador);
            }
            catch (System.Exception)
            {
             
                throw;
            }
        }

    }
}