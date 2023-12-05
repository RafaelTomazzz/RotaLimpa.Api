using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Repositories.Interfaces
{
    public interface IMotoristasRepository
    {
        public Task<IEnumerable<Motorista>> GetAllMotoristasAsync();
        public Task<Motorista> GetMotoristaByIdAsync(int id);
        public Task CreateMotoristaAsync(Motorista novoMotorista);
        public Task RemoveMotorista(Motorista motorista);
        public Task<int> ObterUltimoNumeroLoginAsync();
        public Task<Motorista> GetMotoristaByCPFAsync(string cpf);
        public Task<DateTime> BuscarUltimaCriacao();
        public Task<Motorista> GetMotoristaByLoginAsync(string login);
    }
}
