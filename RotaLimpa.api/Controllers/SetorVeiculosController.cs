using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Services;
using RotaLimpa.Api.Exceptions;

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
                SetorVeiculo setorVeiculo = await _setoresVeiculosService.GetSetorVeiculoByIdAsync(id);
                return Ok(setorVeiculo);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
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
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SetorVeiculo setorVeiculoAlterado)
        {
            try
            {
                SetorVeiculo currentSetorVeiculo = await _setoresVeiculosService.UpdateSetorVeiculoAsync(id, setorVeiculoAlterado);

                return Ok(currentSetorVeiculo);
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
                await _setoresVeiculosService.RemoveSetorVeiculo(id);
                
                return Ok("Deletado com sucesso");
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }
    }
}
