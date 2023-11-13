using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace RotaLimpa.Api.Models
{
    [Table("Rota")]
    [PrimaryKey(nameof(IdRota))]
    public class Rota
    {
        public ICollection<Rua>? Ruas { get; set; }
        public ICollection<Trajeto>? Trajetos { get; set; } 

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_Rota")]
        [NotNull]
        public int IdRota { get; set; }

        [Required]
        [ForeignKey("Id_Colaborador")]
        public int IdColaborador { get; set; }
        public Colaborador Colaborador { get; set; }

        [Required]
        public int SetorId { get; set; }

        [NotMapped]
        public Setor Setor { get; set; }

        [Required]
        [Column("Dt_Rota")]
        [Comment("Distancia da Rota")]
        [NotNull]
        public int DtRota { get; set; }

        [Required]
        [Column("Tm_Rota")]
        [Comment("Tempo médio da Rota")]
        [NotNull]
        public int TmRota { get; set; }
    }
}
