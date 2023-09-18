using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RotaLimpa.Api.Models
{
    [Table("Trajetos")]
    public class Trajeto
    {
        [Key]
        public int Id_Trajeto { get; set; }
        public Motorista Id_Motorista { get; set; }
        public Rota Id_Rota { get; set; }
        public Frota Id_Veiculo { get; set; }
        public DateTime Mi_Trajeto { get; set; }
        public DateTime Mj_Trajeto { get; set; }
    }
}
