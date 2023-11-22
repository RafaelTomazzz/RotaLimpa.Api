using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.DTO.Builder
{
    public class FrotaDTOBuilder
    {
        private FrotaDTO _frotaDTO = new FrotaDTO();

        public FrotaDTOBuilder WithId(int idveiculo)
        {
            _frotaDTO.IdVeiculo = idveiculo;
            return this;
        }

        public FrotaDTOBuilder WithPlaca(string placa)
        {
            _frotaDTO.PVeiculo = placa;
            return this;
        }

        public FrotaDTOBuilder WithTamanho(double tamanho)
        {
            _frotaDTO.TmnVeiculo = tamanho;
            return this;
        }

        public FrotaDTOBuilder WithKilometragem(Kilometragem kilometragem)
        {
            _frotaDTO.Kilometragem = kilometragem;
            return this;
        }

        public FrotaDTO Build()
        {
            return _frotaDTO;
        }
    }
}