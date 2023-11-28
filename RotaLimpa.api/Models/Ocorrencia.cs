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
    [PrimaryKey(nameof(Id))]
    [Index(nameof(Id), IsUnique = true)]
    public class Ocorrencia
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [NotNull]
        public int Id { get; set; }
        
        [Column("Id_Trajeto")]
        [ForeignKey("Id_Trajeto")]
        public int IdTrajeto { get; set; }
        [NotMapped]
        public Trajeto? Trajeto { get; set;}

        [Column("Id_Cep")]
        [ForeignKey("Cep")]
        public int IdCep { get; set; }
        public CEP? CEP { get; set; }

        [Required]
        public TiposOcorrencia TipoOcorrencia { get; set; }
        
        [Required]
        [Column("MtOcorrencia")]
        [Comment("Data domento da ocorr�ncia")]
        [NotNull]
        public DateTime MtOcorrencia { get; set; } = DateTime.Now;
    }
}
