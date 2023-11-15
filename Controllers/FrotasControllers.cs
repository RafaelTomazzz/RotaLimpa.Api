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
    public class FrotasController : ControllerBase
    {
         private readonly DataContext _context;

        public FrotasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Frota> lista = await _context.Frotas.ToListAsync();
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
                Frota frota = await _context.Frotas.FirstOrDefaultAsync(frotaBusca => frotaBusca.IdVeiculo == id);
                return Ok(frota);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Frota novoFrota)
        {
            try
            {
                await _context.Frotas.AddAsync(novoFrota);
                await _context.SaveChangesAsync();

                return Ok(novoFrota);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Frota frotaAlterado)
        {
            try
            {
                _context.Frotas.Update(frotaAlterado);
                await _context.SaveChangesAsync();

                return Ok(frotaAlterado);
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
                Frota frota = await _context.Frotas.FirstOrDefaultAsync(frotaBusca => frotaBusca.IdVeiculo == id);

                _context.Frotas.Remove(frota);
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