using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Index(nameof(Id_Rota), IsUnique = true)]
    [Table("Rotas")]
    public class Rotas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdRota")]
        [NotNull]
        public int Id_Rota { get; set; }

        [ForeignKey("Id_Colaborador")]
        [Required]
        public int Id_Colaborador { get; set; }

        [ForeignKey("Id_Periodos")]
        [Required]
        public int Id_Periodos { get; set; }

        [ForeignKey("Id_Setor")]
        [Required]
        public int Id_Setor { get; set; }

        [Required]
        [Column("dtRota")]
        [Comment("Distancia da Rota")]
        [NotNull]
        public DateTime Dt_Rota { get; set; }

        [Required]
        [Column("tmRota")]
        [Comment("Tempo médio da Rota")]
        [NotNull]
        public TimeSpan Tm_Rota { get; set; }
    }
}
