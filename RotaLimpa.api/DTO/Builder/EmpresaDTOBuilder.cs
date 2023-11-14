using RotaLimpa.Api.DTO;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.DTO.Builder
{
    public class EmpresaDTOBuilder
    {
        private EmpresaDTO _empresaDTO = new EmpresaDTO();

        public EmpresaDTOBuilder WithId(int id)
        {
            _empresaDTO.Id = id;
            return this;
        }

        public EmpresaDTOBuilder WithNome(string nome)
        {
            _empresaDTO.Nome = nome;
            return this;
        }

        public EmpresaDTOBuilder WithDcEmpresa(string dcEmpresa)
        {
            _empresaDTO.DcEmpresa = dcEmpresa;
            return this;
        }

        public EmpresaDTO Build()
        {
            return _empresaDTO;
        }
    }
}