using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Models.Enum;


namespace RotaLimpa.Api.Models
{
    [Table("Ocorrencia")]
    [PrimaryKey(nameof(IdOcorrencia))]
    [Index(nameof(IdOcorrencia), IsUnique = true)]
    public class Ocorrencia
    {
        public ICollection<RelatorioFinal>? RelatoriosFinais { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_Ocorrencia")]
        [NotNull]
        public int IdOcorrencia { get; set; }
        
        [Column("Id_Trajeto")]
        public int IdTrajeto { get; set; }
        public Trajeto Trajeto { get; set; }
        public TiposOcorrencia TipoOcorrencia { get; set; }
        
        [Required]
        [Column("MtOcorrencia")]
        [Comment("Data domento da ocorr�ncia")]
        [NotNull]
        public DateTime MtOcorrencia { get; set; } = DateTime.Now;
    }
}
