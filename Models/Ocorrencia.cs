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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        [NotNull]
<<<<<<< HEAD
        public int Id_Ocorrencia { get; set; }

        [ForeignKey("idTrajeto")]
        public Trajeto Id_Trajeto { get; set; }

        [ForeignKey("tipoOcorrencia")]
        public TiposOcorrencia Tipo_Ocorrencia { get; set; }
=======
        public int IdOcorrencia { get; set; }
        [Column("Id_Trajeto")]
        public Trajeto IdTrajeto { get; set; }
        public TiposOcorrencia TipoOcorrencia { get; set; }
>>>>>>> origin/Rafael
        
        [Required]
        [Column("MtOcorrencia")]
        [Comment("Data domento da ocorrência")]
        [NotNull]
        public DateTime MtOcorrencia { get; set; }
    }
}
