using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace RotaLimpa.Api.Models
{
    [Table("Periodos")]
    public class Periodos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdPeriodo")]
        public int Id_Periodo { get; set; }

        [Required]
        [StringLength(15)]
        [Comment("Descrição do Período")]
        [NotNull]
        public string Ds_Periodo { get; set; }

        [Required]
        [StringLength(5)]
        [Comment("Hora de Início do Período")]
        [NotNull]
        public string Mi_Periodo { get; set; }

        [Required]
        [StringLength(5)]
        [Comment("Hora do fim do Período")]
        [NotNull]
        public string Mf_Periodo { get; set; }
    }
}
