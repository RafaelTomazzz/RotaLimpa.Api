using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Exceptions;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Services;

namespace RotaLimpa.Api.Controllers 
{
    [ApiController]
    [Route("[Controller]")]
    public class KilometragensController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IKilometragensService _kilometragensService;

        public KilometragensController(DataContext context, IKilometragensService kilometragensService)
        {
            _context = context;
            _kilometragensService = kilometragensService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Kilometragem> lista = await _kilometragensService.GetAllKilometragensAsync();
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
                Kilometragem kilometragem = await _kilometragensService.GetKilometragemByIdAsync(id);
                return Ok(kilometragem);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Kilometragem novoKilometragem)
        {
            try
            {
                await _kilometragensService.CreateKilometragemAsync(novoKilometragem);

                return Ok(novoKilometragem);
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Kilometragem kilometragemAlterado)
        {
            try
            {
                Kilometragem currentKilometragem = await _kilometragensService.UpdateKilometragemAsync(id, kilometragemAlterado);

                return Ok(currentKilometragem);
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
                await _kilometragensService.RemoveKilometragem(id);
                
                return Ok("Deletado com sucesso");
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }
    }
}
