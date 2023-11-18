using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RotaLimpa.Api.DTO
{
    public class ColaboradorDTO
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string PNome { get; set; }
        public string SNome { get; set; }
        public string Cpf { get; set; }
        public string Rg{ get; set; }
    }
}