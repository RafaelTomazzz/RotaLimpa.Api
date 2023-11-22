using RotaLimpa.Api.DTO;
using RotaLimpa.Api.Models.Enum;

namespace RotaLimpa.Api.DTO.Builder
{
    public class SetorDTOBuilder
    {
        private SetorDTO _setorDTO = new SetorDTO();

        public SetorDTOBuilder WithId(int id)
        {
            _setorDTO.Id = id;
            return this;
        }

        public SetorDTOBuilder WithIdColaborador(int idcolaborador)
        {
            _setorDTO.IdColaborador = idcolaborador;
            return this;
        }

        public SetorDTOBuilder WithIdEmpresa(int idempresa)
        {
            _setorDTO.IdEmpresa = idempresa;
            return this;
        }

        public SetorDTOBuilder WithTipoServico(TiposServico tiposServico)
        {
            _setorDTO.TipoServico = tiposServico;
            return this;
        }

        public SetorDTO Build()
        {
            return _setorDTO;
        }
    }

}