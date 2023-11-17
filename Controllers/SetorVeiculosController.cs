using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Services;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SetorVeiculosController : ControllerBase
    {
        private readonly DataContext _context;

        private readonly ISetoresVeiculosService _setoresVeiculosService;

        public SetorVeiculosController(DataContext context, ISetoresVeiculosService setoresVeiculosService)
        {
            _context = context;
            _setoresVeiculosService = setoresVeiculosService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<SetorVeiculo> lista = await _setoresVeiculosService.GetAllSetoresVeiculosAsync();
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
                SetorVeiculo setorVeiculo = await _setoresVeiculosService.GetSetorVeiculoByIdAsync(id);
                return Ok(setorVeiculo);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SetorVeiculo novoSetorVeiculo)
        {
            try
            {
                await _setoresVeiculosService.CreateSetorVeiculoAsync(novoSetorVeiculo);

                return Ok(novoSetorVeiculo);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] SetorVeiculo setorVeiculoAlterado)
        {
            try
            {
                SetorVeiculo currentSetorVeiculo = await _setoresVeiculosService.UpdateSetorVeiculoAsync(id, setorVeiculoAlterado);

                return Ok(currentSetorVeiculo);
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
                SetorVeiculo setorVeiculo = await _setoresVeiculosService.GetSetorVeiculoByIdAsync(id);

                await _setoresVeiculosService.RemoveSetorVeiculo(id, setorVeiculo);
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
