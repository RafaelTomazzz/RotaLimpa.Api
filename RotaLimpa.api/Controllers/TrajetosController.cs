using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Services;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TrajetosController : ControllerBase
    {
        private readonly DataContext _context;

        private readonly ITrajetosService _trajetosService;

        public TrajetosController(DataContext context, ITrajetosService trajetosService)
        {
            _context = context;
            _trajetosService = trajetosService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Trajeto> lista = await _trajetosService.GetAllTrajetosAsync();
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
                Trajeto trajeto = await _trajetosService.GetTrajetoByIdAsync(id);
                return Ok(trajeto);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Trajeto novoTrajeto)
        {
            try
            {
                await _trajetosService.CreateTrajetoAsync(novoTrajeto);

                return Ok(novoTrajeto);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] Trajeto trajetoAlterado)
        {
            try
            {
                Trajeto currentTrajeto = await _trajetosService.UpdateTrajetoAsync(id, trajetoAlterado);

                return Ok(currentTrajeto);
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
                await _trajetosService.RemoveTrajeto(id);
                
                return Ok("Deletado com sucesso");
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
