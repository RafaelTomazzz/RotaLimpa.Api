using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Index(nameof(Id_Empresa), IsUnique = true)]
    [PrimaryKey(nameof(Id_Empresa))]
    [Table("Empresas")]
    public class Empresas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdEmpresa")]
        public int Id_Empresa { get; set; }

        [Required]
        [Column("nmEmpresa")]
        [StringLength(40)]
        [NotNull]
        public string Nm_Empresa { get; set; }

        [Required]
        [Column("dcEmpresa")]
        [StringLength(18)]
        [NotNull]
        public string Dc_Empresa { get; set; }

        [Required]
        [Column("stEmpresa")]
        [NotNull]
        public string St_Empresa { get; set; }

        [Required]
        [Column("diEmpresa")]
        [NotNull]
        public DateTime Di_Empresa { get; set; }

        [Required]
        [Column("daEmpresa")]
        [NotNull]
        public DateTime Da_Empresa { get; set; }
    }
}
