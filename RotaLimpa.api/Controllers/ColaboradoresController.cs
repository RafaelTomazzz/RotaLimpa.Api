using System;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Services;
using RotaLimpa.Api.Exceptions;
using RotaLimpa.Api.DTO;
using RotaLimpa.Api.Http;

namespace RotaLimpa.Api.Controllers 
{
    [ApiController]
    [Route("[Controller]")]
    public class ColaboradoresController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IColaboradoresService _colaboradoresService;

        public ColaboradoresController(DataContext context, IColaboradoresService colaboradoresService)
        {
            _context = context;
            _colaboradoresService = colaboradoresService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Colaborador> colaborador = await _colaboradoresService.GetAllColaboradoresAsync();
                IEnumerable<ColaboradorDTO> colaboradorDTO = colaborador.Select(c => c.ToColaborador()); 
                return Ok(colaboradorDTO);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Colaborador colaborador = await _colaboradoresService.GetColaboradorByIdAsync(id);
                ColaboradorDTO colaboradorDTO = colaborador.ToColaborador();
                return Ok(colaboradorDTO);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Colaborador novoColaborador)
        {
            try
            {
                Colaborador colaborador = await _colaboradoresService.CreateColaboradorAsync(novoColaborador);
                ColaboradorDTO colaboradorDTO = colaborador.ToColaborador();

                return HttpResponseApi<ColaboradorDTO>.Created(colaboradorDTO);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Colaborador colaboradorAlterado)
        {
            try
            {
                await _colaboradoresService.UpdateColaboradorAsync(id, colaboradorAlterado);

                return NoContent();
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _colaboradoresService.RemoveColaborador(id);
                
                return NoContent();
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();;
            }
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] RotaLimpa.api.DTO.LoginCDTO request)
        {
            try
            {
                Colaborador colaborador = await _colaboradoresService.AutenticarColaboradorAsync(request.Login, request.Senha);

                if (colaborador != null && colaborador.Login == request.Login)
                {
                    ColaboradorDTO colaboradorDTO = colaborador.ToColaborador();
                    return Ok(colaboradorDTO);
                }
                else
                {
                    return Unauthorized("Credenciais inválidas ou colaborador não encontrado.");
                }
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        [HttpGet("GetEmpresa/{id}")]
        public async Task<IActionResult> EmpresaColaborador(int id)
        {
            try
            {
                Colaborador colaborador = await _context.Colaboradores
                    .Include(c => c.Empresa)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (colaborador == null)
                {
                    return NotFound("Colaborador não encontrado");
                }

                if (colaborador.Empresa == null)
                {
                    return NotFound("Empresa não encontrada para o colaborador");
                }

                EmpresaDTO empresaDTO = colaborador.Empresa.ToEmpresa();
                return Ok(empresaDTO);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }
    }
}