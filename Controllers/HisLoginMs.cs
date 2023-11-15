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
    public class HisLoginMsController : ControllerBase
    {
         private readonly DataContext _context;

        public HisLoginMsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<HisLoginM> lista = await _context.HisLoginMs.ToListAsync();
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
                HisLoginM hisLoginM = await _context.HisLoginMs.FirstOrDefaultAsync(hislBusca => hislBusca.Id == id);
                return Ok(hisLoginM);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(HisLoginM novoHisLoginM)
        {
            try
            {
                await _context.HisLoginMs.AddAsync(novoHisLoginM);
                await _context.SaveChangesAsync();

                return Ok(novoHisLoginM);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(HisLoginM hisLoginMAlterado)
        {
            try
            {
                _context.HisLoginMs.Update(hisLoginMAlterado);
                await _context.SaveChangesAsync();

                return Ok(hisLoginMAlterado);
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
                HisLoginM hisLoginM = await _context.HisLoginMs.FirstOrDefaultAsync(hislBusca => hislBusca.Id == id);

                _context.HisLoginMs.Remove(hisLoginM);
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