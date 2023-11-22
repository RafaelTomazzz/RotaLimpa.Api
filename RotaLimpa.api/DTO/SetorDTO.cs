using RotaLimpa.Api.Models.Enum;

namespace RotaLimpa.Api.DTO
{
    public class SetorDTO{

        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public int IdEmpresa { get; set; }
        public TiposServico TipoServico { get; set; }
    }

}