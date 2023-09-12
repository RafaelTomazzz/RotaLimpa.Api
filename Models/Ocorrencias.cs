using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RotaLimpa.Api.Models.Enuns;
using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;


namespace RotaLimpa.Api.Models
{
    [Index(nameof(Id_Ocorrencia), IsUnique = true)]
    [PrimaryKey(nameof(Id_Ocorrencia))]
    [Table("Ocorrencias")]
    public class Ocorrencias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdOcorrencia")]
        [NotNull]
        public int Id_Ocorrencia { get; set; }
        
        [ForeignKey("Id_Trajeto")]
        [Required]
        [NotNull]
        public int Id_Trajeto { get; set; }
        
        [Required]
        [NotNull]
        public TiposOcorrencias Ocorrencia { get; set; }
        
        [Required]
        [Column("mtOcorrencia")]
        [Comment("Momento da ocorrencia")]
        [NotNull]
        public DateTime Mt_Ocorrencia { get; set; }
    }
}
