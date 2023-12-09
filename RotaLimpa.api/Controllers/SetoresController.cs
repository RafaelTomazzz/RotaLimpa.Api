using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Exceptions;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Services;
using RotaLimpa.Api.DTO;
using RotaLimpa.Api.DTO.Builder;
using RotaLimpa.Api.Http;
using Newtonsoft.Json;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SetoresController : ControllerBase
    {
        private readonly DataContext _context;

        private readonly ISetoresService _setoresService;
        private readonly IEmpresasService _empresasService;
        private readonly IColaboradoresService _colaboradoresService;

        public SetoresController(DataContext context, ISetoresService setoresService, IEmpresasService empresasService, IColaboradoresService colaboradoresService)
        {
            _context = context;
            _setoresService = setoresService;
            _empresasService = empresasService;
            _colaboradoresService = colaboradoresService;
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
        public async Task<IActionResult> GetMotoristas(int id)
        {
            try
            {
                Setor setor = await _context.Setores
                    .Include(rota => rota.Rotas)
                        .ThenInclude(trajeto => trajeto.Trajetos)
                            .ThenInclude(motorista => motorista.Motorista)
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (setor == null)
                {
                    return NotFound("Setor n�o encontrado");
                }

                List<string> nomesMotoristas = new List<string>();

                foreach (var rota in setor.Rotas)
                {
                    foreach (var trajeto in rota.Trajetos)
                    {
                        var motorista = trajeto.Motorista;
                        if (motorista != null)
                        {
                            string nomeMotorista = $"{motorista.PNome} {motorista.SNome}";
                            nomesMotoristas.Add(nomeMotorista);
                        }
                    }
                }

                // Retorne at� tr�s motoristas
                var motoristasParaRetornar = nomesMotoristas.Take(3).ToList();

                return Ok(motoristasParaRetornar);
            }
            catch (BaseException ex)
            {

                return ex.GetResponse();
            }
        }

        [HttpGet("Placa/{id}")]
        public async Task<IActionResult> GetPlacas(int id)
        {
            try
            {
                Setor setor = await _context.Setores
                    .Include(setor => setor.SetorVeiculos)
                        .ThenInclude(setorVeiculo => setorVeiculo.Frota)
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (setor == null)
                {
                    return NotFound("Setor n�o encontrado");
                }

                List<string> placasVeiculos = new List<string>();

                foreach (var setorVeiculo in setor.SetorVeiculos)
                {
                    var placaVeiculo = setorVeiculo.Frota.PVeiculo;
                    placasVeiculos.Add(placaVeiculo);
                }

                return Ok(placasVeiculos);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        [HttpGet("Empresa/{id}")]
        public async Task<IActionResult> GetNomeEmpresa(int id)
        {
            try
            {
                Setor setor = await _setoresService.GetSetorByIdAsync(id);
                int idempresa = setor.IdEmpresa;

                Empresa empresa = await _empresasService.GetEmpresaByIdAsync(idempresa);
                string empresaNome = empresa.Nome;

                return Ok(empresaNome); 
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        [HttpGet("Colaborador/{id}")]
        public async Task<IActionResult> GetNomeColaborador(int id)
        {
            try
            {
                Setor setor = await _setoresService.GetSetorByIdAsync(id);
                int idcolaborador = setor.IdColaborador;

                Colaborador colaborador = await _colaboradoresService.GetColaboradorByIdAsync(idcolaborador); 
                string colaboradorNome = colaborador.PNome + colaborador.SNome;

                return Ok(colaboradorNome); 
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        [HttpGet("Rotas/{id}")]
        public async Task<IActionResult> GetSetorRotas(int id)
        {
            try
            {
                var setor = await _context.Setores
                    .Include(s => s.Rotas)
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (setor == null)
                {
                    return NotFound("Setor não encontrado");
                }

                // Desabilita a referência circular durante a serialização
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                var json = JsonConvert.SerializeObject(setor.Rotas, settings);

                return Content(json, "application/json");
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }
    }
}
