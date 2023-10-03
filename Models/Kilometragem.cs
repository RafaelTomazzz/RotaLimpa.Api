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
    [Table("Kilometragem")]
    [PrimaryKey(nameof(Id_Veiculo))]
    public class Kilometragem
    {
        [Key]
<<<<<<< HEAD
        [NotNull]
        [ForeignKey("idVeiculo")]
=======
>>>>>>> origin/Rafael
        public int Id_Veiculo { get; set; }
        public virtual Frota Frota {get; set; }
        
        [Required]
        [Column("Km")]
        [Comment("Kilometragem do veículo")]
        [NotNull]
        public int Km { get; set; }

        [Required]
        [Column("Se_Kilometragem")]
        [Comment("Sentido da Marcação")]
        [NotNull]
        public string SeKilometragem { get; set; }

        [Required]
        [Column("Di_Kilometragem")]
        [Comment("Data de início marcação")]
        [NotNull]
        public DateTime DiKilometragem { get; set; }
    }
}
