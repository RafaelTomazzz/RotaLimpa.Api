using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RotaLimpa.Api.Models
{
    [Table("Kilometragens")]
    public class Kilometragens
    {
        [Key]
        public Frotas Id_Veiculo { get; set; }
        public int Kilometragem { get; set; }
        public string Se_Kilometragem { get; set; }
        public DateTime Di_Kilometragem { get; set; }
    }
}
