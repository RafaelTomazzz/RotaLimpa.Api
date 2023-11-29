using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RotaLimpa.Api.DTO
{
    public class MotoristaDTO
    {
        public int Id { get; set; }
        public string PNome { get; set; }
        public string SNome { get; set; }
        public string Cpf { get; set; }
        public string Login { get; set; }
    }
}