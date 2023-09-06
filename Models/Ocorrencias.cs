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

        [Required]
        public int Id_Ocorrencia { get; set; }
        public Trajetos Id_Trajeto { get; set; }
        public TiposOcorrencias Ocorrencia { get; set; }
        public DateTime Mt_Ocorrencia { get; set; }
    }
}
