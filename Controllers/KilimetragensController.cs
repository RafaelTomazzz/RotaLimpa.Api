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
    public class KilimetragensController : ControllerBase
    {
        private readonly DataContext _context;

        public KilimetragensController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Kilometragem> lista = await _context.Kilometragens.ToListAsync();
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
                Kilometragem kilometragem = await _context.Kilometragens.FirstOrDefaultAsync(kBusca => kBusca.IdVeiculo == id);
                return Ok(kilometragem);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Kilometragem novaKilometragem)
        {   
            try
            {
                await _context.Kilometragens.AddAsync (novaKilometragem);
                await _context.SaveChangesAsync();

                return Ok(novaKilometragem);
            }
            catch (System.Exception)
            {
             
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Kilometragem kilometragemAlterada)
        {   
            try
            {
                _context.Kilometragens.Update(kilometragemAlterada);
                await _context.SaveChangesAsync();

                return Ok(kilometragemAlterada);
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
                Kilometragem kilometragem = await _context.Kilometragens.FirstOrDefaultAsync(kBusca => kBusca.IdVeiculo == id);

                _context.Kilometragens.Remove(kilometragem);
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
