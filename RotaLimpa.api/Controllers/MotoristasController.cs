using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Services;

namespace RotaLimpa.Api.Controllers 
{
    [ApiController]
    [Route("[Controller]")]
    public class MotoristasController : ControllerBase
    {
        private readonly DataContext _context;

        private readonly IMotoristasService _motoristasService;

        public MotoristasController(DataContext context, IMotoristasService motoristasService)
        {
            _context = context;
            _motoristasService = motoristasService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Motorista> lista = await _motoristasService.GetAllMotoristasAsync();
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
                Motorista motorista = await _motoristasService.GetMotoristaByIdAsync(id);
                return Ok(motorista);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Motorista novoMotorista)
        {
            try
            {
                await _motoristasService.CreateMotoristaAsync(novoMotorista);

                return Ok(novoMotorista);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] Motorista motoristaAlterado)
        {
            try
            {
                Motorista currentMotorista = await _motoristasService.UpdateMotoristaAsync(id, motoristaAlterado);

                return Ok(currentMotorista);
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
                await _motoristasService.RemoveMotorista(id);
                
                return Ok("Deletado com sucesso");
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
