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
    public class CEPsController : ControllerBase
    {
         private readonly DataContext _context;

         private readonly ICEPsService _cepsService;

        public CEPsController(DataContext context, ICEPsService cepsService)
        {
            _context = context;
            _cepsService = cepsService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<CEP> lista = await _cepsService.GetAllCEPsAsync();
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
                CEP cep = await _cepsService.GetCEPByIdAsync(id);
                return Ok(cep);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CEP novoCEP)
        {
            try
            {
                await _cepsService.CreateCEPAsync(novoCEP);

                return Ok(novoCEP);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] CEP cepAlterado)
        {
            try
            {
                CEP currentCEP = await _cepsService.UpdateCEPAsync(id, cepAlterado);

                return Ok(currentCEP);
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
                CEP cep = await _cepsService.GetCEPByIdAsync(id);

                await _cepsService.RemoveCEP(id, cep);
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