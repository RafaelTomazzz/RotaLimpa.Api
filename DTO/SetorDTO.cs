using RotaLimpa.Api.Models.Enum;

namespace RotaLimpa.Api.DTO
{
    public class SetorDTO{

        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public int EmpresaId { get; set; }
        public TiposServico TipoServico { get; set; }
    }

}