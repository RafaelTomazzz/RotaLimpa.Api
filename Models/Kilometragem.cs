using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RotaLimpa.Api.Models
{
    [Table("Kilometragens")]
    [PrimaryKey(nameof(Id_Veiculo))]
    public class Kilometragem
    {
        [Key]
        public int Id_Veiculo { get; set; }
        public virtual Frota Frota {get; set; }
        public int Km { get; set; }
        public string Se_Kilometragem { get; set; }
        public DateTime Di_Kilometragem { get; set; }
    }
}
