using RotaLimpa.Api.Services.Setores;
using RotaLimpa.Api.Repositores.Setores;
using RotaLimpa.Api.Models;


namespace RotaLimpa.Api.Services.Setores
{
    public class SetoresService : ISetoresService
    {
        private readonly ISetoresRepository _setoresRepository;

        public SetoresService(ISetoresRepository setoresRepository)
        {
            _setoresRepository = setoresRepository;
        }

        public async Task<IEnumerable<Setor>> GetAllAsync()
        {
            return await _setoresRepository.GetAllAsync();
        }
    }
}