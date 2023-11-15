using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TrajetosController : ControllerBase
    {
        private readonly DataContext _context;

        public TrajetosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Trajeto> lista = await _context.Trajetos.ToListAsync();
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
                Trajeto trajeto = await _context.Trajetos.FirstOrDefaultAsync(trajetoBusca => trajetoBusca.Id == id);
                return Ok(trajeto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Trajeto novoTrajeto)
        {
            try
            {
                await _context.Trajetos.AddAsync(novoTrajeto);
                await _context.SaveChangesAsync();

                return Ok(novoTrajeto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Trajeto trajetoAlterado)
        {
            try
            {
                _context.Trajetos.Update(trajetoAlterado);
                await _context.SaveChangesAsync();

                return Ok(trajetoAlterado);
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
                Trajeto trajeto = await _context.Trajetos.FirstOrDefaultAsync(trajetoBusca => trajetoBusca.Id == id);

                _context.Trajetos.Remove(trajeto);
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
