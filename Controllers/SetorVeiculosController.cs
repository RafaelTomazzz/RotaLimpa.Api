using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SetorVeiculosController : ControllerBase
    {
        private readonly DataContext _context;

        public SetorVeiculosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<SetorVeiculo> lista = await _context.SetorVeiculos.ToListAsync();
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
                SetorVeiculo setorVeiculo = await _context.SetorVeiculos.FirstOrDefaultAsync(setorVeiBusca => setorVeiBusca.IdSetor == id);
                return Ok(setorVeiculo);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(SetorVeiculo novoSetorVeiculo)
        {
            try
            {
                await _context.SetorVeiculos.AddAsync(novoSetorVeiculo);
                await _context.SaveChangesAsync();

                return Ok(novoSetorVeiculo);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(SetorVeiculo setorVeiculoAlterado)
        {
            try
            {
                _context.SetorVeiculos.Update(setorVeiculoAlterado);
                await _context.SaveChangesAsync();

                return Ok(setorVeiculoAlterado);
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
                SetorVeiculo setorVeiculo = await _context.SetorVeiculos.FirstOrDefaultAsync(setorVeiBusca => setorVeiBusca.IdSetor == id);

                _context.SetorVeiculos.Remove(setorVeiculo);
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
