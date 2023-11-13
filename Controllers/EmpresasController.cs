using System;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EmpresasController : ControllerBase
    {
        private readonly DataContext _context;

        public EmpresasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Empresa> lista = await _context.Empresas.ToListAsync();
                
                return Ok(lista);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Empresa empresa = await _context.Empresas.FirstOrDefaultAsync(empreBusca => empreBusca.IdEmpresa == id);

                return Ok(empresa);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Empresa novaEmpresa)
        {   
            try
            {
                await _context.Empresas.AddAsync(novaEmpresa);
                await _context.SaveChangesAsync();

                return Ok(novaEmpresa);
            }
            catch (System.Exception)
            {
             
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Empresa empresaAlterada)
        {   
            try
            {
                _context.Empresas.Update(empresaAlterada);
                await _context.SaveChangesAsync();

                return Ok(empresaAlterada);
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
                Empresa empresa = await _context.Empresas.FirstOrDefaultAsync(empreBusca => empreBusca.IdEmpresa == id);

                _context.Empresas.Remove(empresa);
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