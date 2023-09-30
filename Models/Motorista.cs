using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Index(nameof(Id_Motorista), IsUnique = true)]
    [PrimaryKey(nameof(Id_Motorista))]
    [Table("Motoristas")]
    public class Motorista
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdMotorista")]
        public int Id_Motorista { get; set; }

        [Required]
        [StringLength(40)]
        [Column("NomeMotorista")]
        [NotNull]
        public string Nm_Motorista { get; set; }

        
        public DateTime Dc_Motorista { get; set; }
        public string St_Motorista { get; set; }
    }
}
