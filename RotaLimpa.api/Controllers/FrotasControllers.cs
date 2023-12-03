using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Exceptions;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.DTO;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Services;
using RotaLimpa.Api.DTO.Builder;
using RotaLimpa.Api.Http;

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
                IEnumerable<Frota> frotas = await _frotasService.GetAllFrotasAsync();
                IEnumerable<FrotaDTO> frotasDTO = frotas.Select(f => f.ToFrota());
                return Ok(frotasDTO);
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
                Frota frota = await _frotasService.GetFrotaByIdAsync(id);
                FrotaDTO frotaDTO = frota.ToFrota();
                return Ok(frotaDTO);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Frota novoFrota)
        {
            try
            {
                Frota frota = await _frotasService.CreateFrotaAsync(novoFrota);
                FrotaDTO frotaDTO = frota.ToFrota();

                return HttpResponseApi<FrotaDTO>.Created(frotaDTO);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Frota frotaAlterado)
        {
            try
            {
                Frota currentFrota = await _frotasService.UpdateFrotaAsync(id, frotaAlterado);

                return Ok(currentFrota);
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
                await _frotasService.RemoveFrota(id);
                
                return Ok("Deletado com sucesso");
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }
    }
}