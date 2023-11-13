using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace RotaLimpa.Api.Models
{
    [Table("Frota")]
    [PrimaryKey(nameof(IdVeiculo))]
    public class Frota
    {
        [Key]
        [Column("Id_Veiculo")]
        [NotNull]
        public int IdVeiculo { get; set; }
        
        [Column("P_Veiculo")]
        public string PVeiculo { get; set; }

        [Comment("Tamanho do ve�culo")]
        [Column("Tmn_Veiculo")]
        public double TmnVeiculo { get; set; }

        [Column("Di_Veiculo")]
        public DateTime DiVeiculo { get; set; }
        
        [Column("St_Veiculo")]
        [StringLength(1)]
        public string StVeiculo { get; set; }

    }
}
