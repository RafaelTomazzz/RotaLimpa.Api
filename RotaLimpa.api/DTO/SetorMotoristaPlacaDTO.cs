using RotaLimpa.Api.DTO;
using RotaLimpa.Api.Models.Enum;


namespace RotaLimpa.Api.DTO
{
    public class SetorMotoristaPlacaDTO
    {
        public TiposServico TipoServico { get; set; }

        public string PNome { get; set; }

        public string SNome { get; set; }

        public string CPF { get; set; }

        public string Placa { get; set;}
    }
}
