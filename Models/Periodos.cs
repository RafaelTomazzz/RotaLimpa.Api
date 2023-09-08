using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace RotaLimpa.Api.Models
{
    [Table("Periodos")]
    public class Periodos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdPeriodo")]
        public int Id_Periodo { get; set; }

        [Required]
        [StringLength(15)]
        [NotNull]
        public string Ds_Periodo { get; set; }

        [Required]
        [StringLength(5)]
        [NotNull]
        public string Mi_Periodo { get; set; }

        [Required]
        [StringLength(5)]
        [NotNull]
        public string Mf_Periodo { get; set; }
    }
}
