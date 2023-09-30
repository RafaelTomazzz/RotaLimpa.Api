using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Index(nameof(Id_Veiculo), IsUnique = true)]
    [PrimaryKey(nameof(Id_Veiculo))]
    [Table("Frotas")]
    public class Frota
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdVeiculo")]
        public int Id_Veiculo { get; set; }

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
