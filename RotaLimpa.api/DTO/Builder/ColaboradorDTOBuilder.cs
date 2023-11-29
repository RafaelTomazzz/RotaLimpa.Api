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

        public ColaboradorDTOBuilder WithLogin(string login)
        {
            _colaboradorDTO.Login = login;
            return this;
        }

        public ColaboradorDTOBuilder WithIdEmpresa(int idempresa)
        {
            _colaboradorDTO.IdEmpresa = idempresa;
            return this;
        }

        public ColaboradorDTOBuilder WithPNome(string pnome)
        {
            _colaboradorDTO.PNome = pnome;
            return this;
        }

        public ColaboradorDTOBuilder WithSNome(string snome)
        {
            _colaboradorDTO.SNome = snome;
            return this;
        }

        public ColaboradorDTOBuilder WithCpf(string cpf)
        {
            _colaboradorDTO.Cpf = cpf;
            return this;
        }
        
        public ColaboradorDTOBuilder WithRg(string rg)
        {
            _colaboradorDTO.Rg = rg;
            return this;
        }

        public ColaboradorDTO Builder()
        {
            return _colaboradorDTO;
        }
    }
}