using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using RotaLimpa.Api.Models.Enuns;

namespace RotaLimpa.Api.Models
{
    [Index(nameof(Id_Veiculo), IsUnique = true)]
    [PrimaryKey(nameof(Id_Veiculo))]
    [Table("SetorVeiculos")]
    public class SetorVeiculos
    {
        [Key]
        [Required]
        [ForeignKey("Id_Setor")]
        public Setores Id_Setor { get; set; }

        [Key]
        [Required]
        [Column("Id_Veiculo")]
        public Frotas Id_Veiculo { get; set; }
    }
}
