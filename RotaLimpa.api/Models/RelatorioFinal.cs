using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace RotaLimpa.Api.Models
{
    [Table("RelatorioFinal")]
    [PrimaryKey(nameof(IdRelatorio))]
    public class RelatorioFinal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_Relatorio")]
        [NotNull]
        public int IdRelatorio { get; set; }

        [Required]
        [ForeignKey("Id_Setor")]
        public int IdSetor { get; set; }
        public Setor Setor { get; set; }

        [Required]
        [ForeignKey("Id_Trajeto")]
        public int IdTrajeto { get; set; }
        public virtual Trajeto Trajeto { get; set; }
    }
}
