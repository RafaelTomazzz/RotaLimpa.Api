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
    [Table("Ocorrencias")]
    [PrimaryKey(nameof(Id_Ocorrencia))]
    [Index(nameof(Id_Ocorrencia), IsUnique = true)]
    public class Ocorrencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdOcorrencia")]
        [NotNull]
        public int Id_Ocorrencia { get; set; }
        public Trajeto Id_Trajeto { get; set; }
        public TiposOcorrencia Tipo_Ocorrencia { get; set; }
        
        [Required]
        [Column("mtOcorrencia")]
        [Comment("Momento da ocorrencia")]
        [NotNull]
        public DateTime Mt_Ocorrencia { get; set; }
    }
}
