using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Exceptions;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.DTO;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Services;
using RotaLimpa.Api.Http;

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
                IEnumerable<Motorista> motoristas = await _motoristasService.GetAllMotoristasAsync();
                IEnumerable<MotoristaDTO> motoristasDTO = motoristas.Select(m => m.ToMotorista());
                return Ok(motoristasDTO);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Motorista motorista = await _motoristasService.GetMotoristaByIdAsync(id);
                MotoristaDTO motoristaDTO = motorista.ToMotorista();
                return Ok(motoristaDTO);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Motorista novoMotorista)
        {
            try
            {
                Motorista motorista = await _motoristasService.CreateMotoristaAsync(novoMotorista);
                MotoristaDTO motoristaDTO = motorista.ToMotorista();

                return HttpResponseApi<MotoristaDTO>.Created(motoristaDTO);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Motorista motoristaAlterado)
        {
            try
            {
                Motorista currentMotorista = await _motoristasService.UpdateMotoristaAsync(id, motoristaAlterado);

                return Ok(currentMotorista);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
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
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }
    }
}
