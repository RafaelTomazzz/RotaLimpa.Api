using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace RotaLimpa.Api.Models
{
    [Table("Rotas")]
    [PrimaryKey(nameof(Id))]
    public class Rota
    {
        public ICollection<Rua>? Ruas { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdRota")]
        [NotNull]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("idColaborador")]
        public int Id_Colaborador { get; set; }
        public virtual Colaborador Colaborador{ get; set; }

        [Required]
        [ForeignKey("idPeriodo")]
        public int Id_Periodo { get; set; }
        public virtual Periodo Periodo { get; set; }

        [Required]
        [ForeignKey("idSetor")]
        public int Id_Setor {get; set; }
        [NotMapped]
        public virtual Setor Setor { get; set; }

        [Required]
        [Column("dtRota")]
        [Comment("Distancia da Rota")]
        [NotNull]
        public int Dt_Rota { get; set; }

        [Required]
        [Column("tmRota")]
        [Comment("Tempo médio da Rota")]
        [NotNull]
        public int Tm_Rota { get; set; }
    }
}
