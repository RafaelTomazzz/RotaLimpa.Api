using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Services;

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
                IEnumerable<Motorista> lista = await _motoristasService.GetAllMotoristasAsync();
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
                Motorista motorista = await _motoristasService.GetMotoristaByIdAsync(id);
                return Ok(motorista);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Motorista novoMotorista)
        {
            try
            {
                await _motoristasService.CreateMotoristaAsync(novoMotorista);

                return Ok(novoMotorista);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] Motorista motoristaAlterado)
        {
            try
            {
                Motorista currentMotorista = await _motoristasService.UpdateMotoristaAsync(id, motoristaAlterado);

                return Ok(currentMotorista);
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
                Motorista motorista = await _motoristasService.GetMotoristaByIdAsync(id);

                await _motoristasService.RemoveMotorista(id, motorista);
                int linhaAfetada = await _context.SaveChangesAsync();
                
                return Ok(linhaAfetada);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public string GenerarUnicoLogin()
        {
            int proximoNumeroLogin = PegarProximoNumeroLivreLogin();
            string parteData = DateTime.Now.ToString("MMyy");
            return $"{proximoNumeroLogin:D3}{parteData}";
        }

        private int PegarProximoNumeroLivreLogin()
        {
            int currentYear = DateTime.Now.Year;

            if (!_context.Motoristas.Any() || _context.Motoristas.Max(m => m.Di_Motorista.Year) != currentYear)
            {
                return 1;
            }

            int ultimoNumeroLogin = _context.Motoristas.Where(m => m.Di_Motorista.Year == currentYear)
                .Select(m => int.Parse(m.Login.Substring(3, 3)))
                .DefaultIfEmpty(0)
                .Max();

            if (ultimoNumeroLogin >= 999)
            {
                return 1;
            }

            return ultimoNumeroLogin + 1;
        }
    }
}
