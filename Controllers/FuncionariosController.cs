using Microsoft.AspNetCore.Mvc;
using RotaLimpa.api.Data;
using RotaLimpa.api.Models;
using Microsoft.EntityFrameworkCore;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FuncionariosController : ControllerBase
    {
        private readonly DataContext _context;

        public FuncionariosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                List<Funcionario> lista = await _context.Funcionarios.ToListAsync();
                // return Ok(lista);
                return Ok(lista);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Funcionario novofuncionario)
        {   
            try
            {
                await _context.Funcionarios.AddAsync (novofuncionario);
                await _context.SaveChangesAsync();

                return Ok(novofuncionario);
            }
            catch (System.Exception)
            {
             
                throw;
            }
        }

    }
}