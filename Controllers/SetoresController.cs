using System;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using RotaLimpa.Api.Models.inputs;
using RotaLimpa.Api.DTO;
using RotaLimpa.Api.Services.Setores;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SetoresController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ISetoresService _setoresService;

        public SetoresController(DataContext context, ISetoresService setoresService)
        {
            _context = context;
            _setoresService = setoresService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Setor> setores = await _setoresService.GetAllAsync();
                IEnumerable<SetorDTO> setoresDTO = setores.Select(setor => setor.ToSetor());
                return Ok(setoresDTO);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Setor s = await _context.Setores.FirstOrDefaultAsync(s => s.Id == id);
                return Ok(s);
                
            }
            catch (System.Exception ex)
            {
                return BadRequest (ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Setor novosetor)
        {   
            try
            {
                await _context.Setores.AddAsync(novosetor);
                await _context.SaveChangesAsync();

                return Ok(novosetor);
            }
            catch (System.Exception ex)
            {
             
                return BadRequest(ex.Message);
            }
        }
    }
}