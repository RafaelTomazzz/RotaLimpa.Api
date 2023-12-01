using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RotaLimpa.Api.DTO.Builder
{
    public class MotoristaDTOBuilder
    {
        private MotoristaDTO _motoristaDTO = new MotoristaDTO();

        public MotoristaDTOBuilder WithId(int id)
        {
            _motoristaDTO.Id = id;
            return this;
        }

        public MotoristaDTOBuilder WithLogin(string login)
        {
            _motoristaDTO.Login = login;
            return this;
        }

        public MotoristaDTOBuilder WithPNome(string pnome)
        {
            _motoristaDTO.PNome = pnome;
            return this;
        }

        public MotoristaDTOBuilder WithSNome(string snome)
        {
            _motoristaDTO.SNome = snome;
            return this;
        }

        public MotoristaDTOBuilder WithCpf(string cpf)
        {
            _motoristaDTO.Cpf = cpf;
            return this;
        }

        public MotoristaDTO Build()
        {
            return _motoristaDTO;
        }
    }
}