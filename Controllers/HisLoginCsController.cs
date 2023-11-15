using System;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class HisLoginCsController : ControllerBase
    {
         private readonly DataContext _context;

        public HisLoginCsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<HisLoginC> lista = await _context.HisLoginCs.ToListAsync();
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
                HisLoginC hisLoginC = await _context.HisLoginCs.FirstOrDefaultAsync(hislBusca => hislBusca.Id == id);
                return Ok(hisLoginC);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(HisLoginC novoHisLoginC)
        {
            try
            {
                await _context.HisLoginCs.AddAsync(novoHisLoginC);
                await _context.SaveChangesAsync();

                return Ok(novoHisLoginC);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(HisLoginC hisLoginCAlterado)
        {
            try
            {
                _context.HisLoginCs.Update(hisLoginCAlterado);
                await _context.SaveChangesAsync();

                return Ok(hisLoginCAlterado);
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
                HisLoginC hisLoginC = await _context.HisLoginCs.FirstOrDefaultAsync(hislBusca => hislBusca.Id == id);

                _context.HisLoginCs.Remove(hisLoginC);
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