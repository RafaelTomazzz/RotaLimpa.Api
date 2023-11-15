using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RotasController : ControllerBase
    {
        private readonly DataContext _context;

        public RotasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Rota> lista = await _context.Rotas.ToListAsync();
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
                Rota rota = await _context.Rotas.FirstOrDefaultAsync(rotaBusca => rotaBusca.Id == id);
                return Ok(rota);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Rota novaRota)
        {
            try
            {
                await _context.Rotas.AddAsync(novaRota);
                await _context.SaveChangesAsync();

                return Ok(novaRota);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Rota rotaAlterada)
        {
            try
            {
                _context.Rotas.Update(rotaAlterada);
                await _context.SaveChangesAsync();

                return Ok(rotaAlterada);
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
                Rota rota = await _context.Rotas.FirstOrDefaultAsync(rotabusca => rotabusca.Id == id);

                _context.Rotas.Remove(rota);
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
