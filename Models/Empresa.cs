using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Table("Empresa")]
    public class Empresa
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_Empresa")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("Nome da Empresa")]
        [NotNull]
        public string Nome { get; set; }

        [Required]
        [StringLength(14)]
        [Column("CNPJ")]
        [NotNull]
        public string CNPJ { get; set; } 
        
    }
}