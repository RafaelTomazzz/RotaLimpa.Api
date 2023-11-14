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
    public class MotoristasController : ControllerBase
    {
        private readonly DataContext _context;

        public MotoristasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Motorista> lista = await _context.Motoristas.ToListAsync();
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
                Motorista motorista = await _context.Motoristas.FirstOrDefaultAsync(motoriBusca => motoriBusca.Id == id);
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
                await _context.Motoristas.AddAsync(novoMotorista);
                await _context.SaveChangesAsync();

                return Ok(novoMotorista);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Motorista motoristaAlterado)
        {
            try
            {
                _context.Motoristas.Update(motoristaAlterado);
                await _context.SaveChangesAsync();

                return Ok(motoristaAlterado);
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
                Motorista motorista = await _context.Motoristas.FirstOrDefaultAsync(motoriBusca => motoriBusca.Id == id);

                _context.Motoristas.Remove(motorista);
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
