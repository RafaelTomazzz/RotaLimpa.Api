using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RuasController : ControllerBase
    {
        private readonly DataContext _context;

        public RuasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Rua> lista = await _context.Ruas.ToListAsync();
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
                Rua rua = await _context.Ruas.FirstOrDefaultAsync(rotaBusca => rotaBusca.Id == id);
                return Ok(rua);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Rua novaRua)
        {
            try
            {
                await _context.Ruas.AddAsync(novaRua);
                await _context.SaveChangesAsync();

                return Ok(novaRua);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Rua ruaAlterada)
        {
            try
            {
                _context.Ruas.Update(ruaAlterada);
                await _context.SaveChangesAsync();

                return Ok(ruaAlterada);
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
                Rua rua = await _context.Ruas.FirstOrDefaultAsync(ruaBusca => ruaBusca.Id == id);

                _context.Ruas.Remove(rua);
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
