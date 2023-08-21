using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.api.Models
{
    [Index(nameof(Id_Funcionario), IsUnique = true)]
    [PrimaryKey(nameof(Id_Funcionario))]
    [Table("funcionario")]

    public class Funcionario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_Funcionario")]
        public int Id_Funcionario {get; set; }

        [Required]
        [Column("Id_Empresa")]
        [NotNull]
        public int Id_Empresa { get; set; }

        [Required]
        [StringLength(100)]
        [Column("Nome")]
        [NotNull]
        public string Nome { get; set;}

        [Required]
        [StringLength(14)]
        [Column("CPF")]
        [NotNull]
        public string CPF { get; set; }
        
        [Required]
        [StringLength(100)]
        [Column("Tipo_Funcionario")]
        [NotNull]
        public string Tipo_Funcionario {get; set; }
    }
}