using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RotaLimpa.Api.Models
{
    [Table("Kilometragens")]
    [PrimaryKey(nameof(Id_Veiculo))]
    public class Kilometragem
    {
        [Key]
        [NotNull]
        public int Id_Veiculo { get; set; }
        public virtual Frota Frota {get; set; }
        
        [Required]
        [Column("Kilometragem")]
        [NotNull]
        public int Km { get; set; }

        [Required]
        [Column("seKilometragem")]
        [Comment("Sentido da Marcação")]
        [NotNull]
        public string Se_Kilometragem { get; set; }

        [Required]
        [Column("diKilometragem")]
        [Comment("Data de início marcação")]
        [NotNull]
        public DateTime Di_Kilometragem { get; set; }
    }
}
