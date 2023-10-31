using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RotaLimpa.Api.Models.Enum;

namespace RotaLimpa.Api.Models.inputs
{
    public class SetorInput
    {
        public int ColaboradorId { get; set; }
        public int EmpresaId { get; set; }
        public TiposServico TipoServico { get; set; }
        public string StSetor { get; set; }
    }
}