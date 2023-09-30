using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace RotaLimpa.Api.Models
{
    [Table("Periodos")]
    [PrimaryKey(nameof(Id))]
    public class Periodo
    {
        public ICollection<Rota>? Rotas { get; set; }

        [Key]
        public int Id { get; set; }
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
