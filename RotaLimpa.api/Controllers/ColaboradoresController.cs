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

        [HttpPost("Authenticate/{id}")]
        public async Task<IActionResult> Authenticate(int id, [FromBody] RotaLimpa.api.DTO.LoginCDTO request)
        {
            try
            {
                if (id != request.Id)
                {
                    return BadRequest("O ID do Colaborador na URL não corresponde ao ID fornecido na solicitação.");
                }

                    Colaborador colaborador = await _colaboradoresService.AutenticarColaboradorAsync(id, request.Login, request.Senha);
                
                if (colaborador != null && colaborador.Id == id)
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
    }
}