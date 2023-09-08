using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Index(nameof(Id_Veiculo), IsUnique = true)]
    [PrimaryKey(nameof(Id_Veiculo))]
    [Table("Kilometragens")]
    public class Kilometragens
    {
        [Key]
        [ForeignKey("Id_Veiculo")]
        [NotNull]
        public Frotas Id_Veiculo { get; set; }

        [Required]
        [Column("Kilometragem")]
        [NotNull]
        public int Kilometragem { get; set; }

        [Required]
        [Column("seKilometragem")]
        [NotNull]
        public string Se_Kilometragem { get; set; }

        [Required]
        [Column("diKilometragem")]
        [NotNull]
        public DateTime Di_Kilometragem { get; set; }
    }
}
