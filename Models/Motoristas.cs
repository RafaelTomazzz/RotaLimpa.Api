using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RotaLimpa.Api.Models
{
    [Table("Motoristas")]
    public class Motoristas
    {
        [Key]
        public int Id_Motorista { get; set; }
        public string Nm_Motorista { get; set; }
        public DateTime Dc_Motorista { get; set; }
        public string St_Motorista { get; set; }
    }
}
