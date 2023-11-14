using RotaLimpa.Api.DTO;

namespace RotaLimpa.Api.DTO.Builder
{
    public class ColaboradorDTOBuilder
    {
        private ColaboradorDTO _colaboradorDTO = new ColaboradorDTO();
        
        public ColaboradorDTOBuilder WithId(int id)
        {
            _colaboradorDTO.Id = id;
            return this;
        }

        public ColaboradorDTOBuilder WithEmpresaId(int empresaId)
        {
            _colaboradorDTO.EmpresaId = empresaId;
            return this;
        }

        public ColaboradorDTOBuilder WithNome(string nome)
        {
            _colaboradorDTO.Nome = nome;
            return this;
        }

        public ColaboradorDTOBuilder WithDc(string dc)
        {
            _colaboradorDTO.DcColaborador = dc;
            return this;
        }

        public ColaboradorDTO Builder()
        {
            return _colaboradorDTO;
        }
    }
}