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
        public ICollection<SetorVeiculo>? SetorVeiculos { get; set; }
        public ICollection<Trajeto>? Trajetos { get; set; } 
        [Key]
        [Column("Id")]
        public int IdVeiculo { get; set; }
        [Column("P_Veiculo")]
        public string PVeiculo { get; set; }
        [Comment("Tamanho do ve�culo")]
        [Column("Tmn_Veiculo")]
        public double TmnVeiculo { get; set; }
        [Column("Di_Veiculo")]
        public DateTime DiVeiculo { get; set; }
        [Column("St_Veiculo")]
        public string StVeiculo { get; set; }
        public Kilometragem Kilometragem { get; internal set; }

    }
}
