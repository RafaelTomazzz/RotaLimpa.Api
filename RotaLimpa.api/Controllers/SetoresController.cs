using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Exceptions;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Services;
using RotaLimpa.Api.DTO;
using RotaLimpa.Api.DTO.Builder;
using RotaLimpa.Api.Http;

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
                Setor setor = await _setoresService.GetSetorByIdAsync(id);
                SetorDTO setorDTO = setor.ToSetor();
                return Ok(setorDTO);
            }
            catch (BaseException ex)
            {

                return ex.GetResponse();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Setor novoSetor)
        {
            try
            {
                Setor setor = await _setoresService.CreateSetorAsync(novoSetor);
                SetorDTO setorDTO = setor.ToSetor();

                return HttpResponseApi<SetorDTO>.Created(setorDTO);
            }
            catch (BaseException ex)
            {

                return ex.GetResponse();
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
                await _setoresService.RemoveSetor(id);
                
                return Ok("Deletado com sucesso");
            }
            catch (BaseException ex)
            {
                
                return ex.GetResponse();
            }
        }

        [HttpGet("Motorista/{id}")]
        public async Task<IActionResult> GetMotorista(int id)
        {
            try
            {
                Setor setor = await _context.Setores
                    .Include(rota => rota.Rotas)
                        .ThenInclude(trajeto => trajeto.Trajetos)
                            .ThenInclude(motorista => motorista.Motorista)
                    .FirstOrDefaultAsync(s => s.Id == id);


                return Ok(setor);
            }
            catch (BaseException ex)
            {

                return ex.GetResponse();
            }
        }
    }
}
