using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        [Comment("Tamanho do ve�culo")]
        [Column("Tmn_Veiculo")]
        public double TmnVeiculo { get; set; }
        [Column("Di_Veiculo")]
        public DateTime DiVeiculo { get; set; }
        [Column("St_Veiculo")]
        public string StVeiculo { get; set; }

        [Required]
        [Column("pVeiculo")]
        [Comment("Placa do Veiculo")]
        [NotNull]
        public string P_Veiculo { get; set; }

        [Required]
        [Column("tmnVeiculo")]
        [NotNull]

        public float Tmn_Veiculo { get; set; }

        [Required]
        [Column("diVeiculo")]
        [NotNull]
        public DateTime Di_Veiculo { get; set; }

        [Required]
        [Column("stVeiculo")]
        [Comment("Setor do Veiculo")]
        [NotNull]
        public string St_Veiculo { get; set; }
    }
}
