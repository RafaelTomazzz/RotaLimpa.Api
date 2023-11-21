using RotaLimpa.Api.Services.Setores;
using RotaLimpa.Api.Repositories.Setores;
using RotaLimpa.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection.Metadata.Ecma335;
using RotaLimpa.Api.Exceptions;


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

        public async Task<Setor> GetByIdAsync(int id)
        {
            Setor  setor = await _setoresRepository.GetByIdAsync(id);

            if (setor is null)
            {
                throw new NotFoundException("Setor");
            }

            return setor;
        }
    }
}