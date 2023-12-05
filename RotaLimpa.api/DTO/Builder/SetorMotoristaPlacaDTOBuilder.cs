using RotaLimpa.Api.Models.Enum;
using System.Numerics;


namespace RotaLimpa.Api.DTO.Builder
{
    public class SetorMotoristaPlacaDTOBuilder
    {
        private SetorMotoristaPlacaDTO _setormotoristaDTO = new SetorMotoristaPlacaDTO();

        public SetorMotoristaPlacaDTOBuilder WithTipoServico(TiposServico tiposServico)
        {
            _setormotoristaDTO.TipoServico = tiposServico;
            return this;
        }

        public SetorMotoristaPlacaDTOBuilder WithPNome(string pNome)
        {
            _setormotoristaDTO.PNome = pNome;
            return this;
        }

        public SetorMotoristaPlacaDTOBuilder WithSNome(string sNome)
        {
            _setormotoristaDTO.SNome = sNome;
            return this;
        }

        public SetorMotoristaPlacaDTOBuilder WithCPF(string cpf)
        {
            _setormotoristaDTO.CPF = cpf;
            return this;
        }

        public SetorMotoristaPlacaDTOBuilder WithPlaca(string placa)
        {
            _setormotoristaDTO.Placa = placa;
            return this;
        }

        public SetorMotoristaPlacaDTO Build()
        {
            return _setormotoristaDTO;
        }
    }
}
