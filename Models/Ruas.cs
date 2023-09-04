using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RotaLimpa.Api.Models
{
    [Table("Ruas")]
    public class Ruas
    {
        [Key]
        public int Id_Ruas { get; set; }
        public CEP Cep { get; set; }
        public Rotas Id_Rota { get; set; }
    }
}
