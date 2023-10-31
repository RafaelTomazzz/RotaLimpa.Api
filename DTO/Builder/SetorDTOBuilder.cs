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

        public SetorDTOBuilder WithColaboradorId(int colaboradorid)
        {
            _setorDTO.ColaboradorId = colaboradorid;
            return this;
        }

        public SetorDTOBuilder WithEmpresaId(int empresaid)
        {
            _setorDTO.EmpresaId = empresaid;
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