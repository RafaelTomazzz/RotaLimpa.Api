using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CEPsController : ControllerBase
    {
         private readonly DataContext _context;

        public CEPsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<CEP> lista = await _context.CEPs.ToListAsync();
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
                CEP cep = await _context.CEPs.FirstOrDefaultAsync(ceepBusca => ceepBusca.Id == id);
                return Ok(cep);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(CEP novoCEP)
        {
            try
            {
                await _context.CEPs.AddAsync(novoCEP);
                await _context.SaveChangesAsync();

                return Ok(novoCEP);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(CEP cepAlterado)
        {
            try
            {
                _context.CEPs.Update(cepAlterado);
                await _context.SaveChangesAsync();

                return Ok(cepAlterado);
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
                CEP cep = await _context.CEPs.FirstOrDefaultAsync(ceepBusca => ceepBusca.Id == id);

                _context.CEPs.Remove(cep);
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