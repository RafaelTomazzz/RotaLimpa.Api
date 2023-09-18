using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RotaLimpa.Api.Models
{
    [Table("Frotas")]
    public class Frota
    {
        [Key]
        public int Id_Veiculo { get; set; }
        public string P_Veiculo { get; set; }
        public float Tmn_Veiculo { get; set; }
        public DateTime Di_Veiculo { get; set; }
        public string St_Veiculo { get; set; }

    }
}
