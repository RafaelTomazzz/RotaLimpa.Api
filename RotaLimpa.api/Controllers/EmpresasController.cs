using System;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Exceptions;
using System.Threading.Tasks;
using RotaLimpa.Api.Services;
using RotaLimpa.Api.DTO;
using RotaLimpa.Api.Http;

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
                IEnumerable<Empresa> empresas = await _empresasService.GetAllEmpresasAsync();
                IEnumerable<EmpresaDTO> empresasDTO = empresas.Select(e => e.ToEmpresa());
                return Ok(empresasDTO);
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
                Empresa empresa = await _empresasService.GetEmpresaByIdAsync(id);
                EmpresaDTO empresaDTO = empresa.ToEmpresa();
                return Ok(empresaDTO);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Empresa novoEmpresa)
        {
            try
            {
                //await _empresasService.CreateEmpresaAsync(novoEmpresa);

                Empresa empresa = await _empresasService.CreateEmpresaAsync(novoEmpresa);
                EmpresaDTO empresaDTO = empresa.ToEmpresa();

                return HttpResponseApi<EmpresaDTO>.Created(empresaDTO);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Empresa empresaAlterado)
        {
            try
            {
                Empresa currentEmpresa = await _empresasService.UpdateEmpresaAsync(id, empresaAlterado);

                return Ok(currentEmpresa);
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
                await _empresasService.RemoveEmpresa(id);
                
                return Ok("Deletado com sucesso");
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }
    }
}