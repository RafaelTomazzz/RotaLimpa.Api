using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Services;
using RotaLimpa.Api.DTO;
using RotaLimpa.Api.DTO.Builder;

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
                IEnumerable<Setor> setores = await _setoresService.GetAllSetoresAsync();
                IEnumerable<SetorDTO> setoresDTO = setores.Select(s => s.ToSetor());
                return Ok(setoresDTO);
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
                Setor setor = await _setoresService.GetSetorByIdAsync(id);
                SetorDTO setorDTO = setor.ToSetor();
                return Ok(setorDTO);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Setor novoSetor)
        {
            try
            {
                await _setoresService.CreateSetorAsync(novoSetor);

                return Ok(novoSetor);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Setor setorAlterado)
        {
            try
            {
                Setor currentSetor = await _setoresService.UpdateSetorAsync(id, setorAlterado);

                return Ok(currentSetor);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _setoresService.RemoveSetor(id);
                
                return Ok("Deletado com sucesso");
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
