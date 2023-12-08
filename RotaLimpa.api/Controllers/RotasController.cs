using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Exceptions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Services;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RotasController : ControllerBase
    {
        private readonly DataContext _context;

        private readonly IRotasService _rotasService;

        public RotasController(DataContext context, IRotasService rotasService)
        {
            _context = context;
            _rotasService = rotasService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Rota> lista = await _rotasService.GetAllRotasAsync();
                return Ok(lista);
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
                Rota rota = await _rotasService.GetRotaByIdAsync(id);
                return Ok(rota);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Rota novoRota)
        {
            try
            {
                await _rotasService.CreateRotaAsync(novoRota);

                return Ok(novoRota);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Rota rotaAlterado)
        {
            try
            {
                Rota currentRota = await _rotasService.UpdateRotaAsync(id, rotaAlterado);

                return Ok(currentRota);
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
                await _rotasService.RemoveRota(id);
                
                return Ok("Deletado com sucesso");
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpGet("Latitude/{id}")]
        public async Task<IActionResult> GetLatitude(int id)
        {
            try
            {
                Rota rota = await _context.Rotas
                    .Include(rua => rua.Ruas)
                        .ThenInclude(cep => cep.CEP)
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (rota == null)
                {
                    return NotFound("Rota não encontrada");
                }

                List<string> lats = new List<string>();

                foreach (var rua in rota.Ruas)
                {
                    var lat = rua.CEP.Latitude;
                    lats.Add(lat);
                }

                return Ok(lats);
            }
            catch (BaseException ex)
            {

                return ex.GetResponse();
            }
        }

        [HttpGet("Longitude/{id}")]
        public async Task<IActionResult> Getlongitude(int id)
        {
            try
            {
                Rota rota = await _context.Rotas
                    .Include(rua => rua.Ruas)
                        .ThenInclude(cep => cep.CEP)
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (rota == null)
                {
                    return NotFound("Rota não encontrada");
                }

                List<string> logs = new List<string>();

                foreach (var rua in rota.Ruas)
                {
                    var log = rua.CEP.Longitude;
                    logs.Add(log);
                }

                return Ok(logs);
            }
            catch (BaseException ex)
            {

                return ex.GetResponse();
            }
        }
    }
}
