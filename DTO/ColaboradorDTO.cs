using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RotaLimpa.Api.DTO
{
    public class ColaboradorDTO
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string Nome { get; set; }
        public string DcColaborador { get; set; }
    }
}