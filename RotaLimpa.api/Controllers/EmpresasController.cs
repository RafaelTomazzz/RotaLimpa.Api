using System;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RotaLimpa.Api.Services;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EmpresasController : ControllerBase
    {
        private readonly DataContext _context;

        private readonly IEmpresasService _empresasService;

        public EmpresasController(DataContext context, IEmpresasService empresasService)
        {
            _context = context;
            _empresasService = empresasService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Empresa> lista = await _empresasService.GetAllEmpresasAsync();
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
                Empresa empresa = await _empresasService.GetEmpresaByIdAsync(id);
                return Ok(empresa);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Empresa novoEmpresa)
        {
            try
            {
                await _empresasService.CreateEmpresaAsync(novoEmpresa);

                return Ok(novoEmpresa);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] Empresa empresaAlterado)
        {
            try
            {
                Empresa currentEmpresa = await _empresasService.UpdateEmpresaAsync(id, empresaAlterado);

                return Ok(currentEmpresa);
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
                Empresa empresa = await _empresasService.GetEmpresaByIdAsync(id);

                await _empresasService.RemoveEmpresa(id, empresa);
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