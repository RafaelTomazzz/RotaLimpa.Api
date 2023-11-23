using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.DTO;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Services;
using RotaLimpa.Api.DTO.Builder;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FrotasController : ControllerBase
    {
         private readonly DataContext _context;

         private readonly IFrotasService _frotasService;

        public FrotasController(DataContext context, IFrotasService frotasService)
        {
            _context = context;
            _frotasService = frotasService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Frota> lista = await _frotasService.GetAllFrotasAsync();
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
                Frota frota = await _frotasService.GetFrotaByIdAsync(id);
                return Ok(frota);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Frota novoFrota)
        {
            try
            {
                await _frotasService.CreateFrotaAsync(novoFrota);

                return Ok(novoFrota);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] Frota frotaAlterado)
        {
            try
            {
                Frota currentFrota = await _frotasService.UpdateFrotaAsync(id, frotaAlterado);

                return Ok(currentFrota);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _frotasService.RemoveFrota(id);
                
                return Ok("Deletado com sucesso");
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}