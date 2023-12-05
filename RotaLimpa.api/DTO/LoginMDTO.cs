using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RotaLimpa.api.DTO
{
    public class LoginMDTO
    {
        public int Id { get; set;}
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}