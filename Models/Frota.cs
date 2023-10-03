using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RotaLimpa.Api.Models
{
    [Table("Frota")]
    public class Frota
    {
        [Key]
        [Column("Id")]
        public int Id_Veiculo { get; set; }
        [Column("P_Veiculo")]
        public string PVeiculo { get; set; }
        [Comment("Tamanho do veículo")]
        [Column("Tmn_Veiculo")]
        public double TmnVeiculo { get; set; }
        [Column("Di_Veiculo")]
        public DateTime DiVeiculo { get; set; }
        [Column("St_Veiculo")]
        public string StVeiculo { get; set; }

    }
}
