using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using RotaLimpa.Api.Models.Enuns;

namespace RotaLimpa.Api.Models
{
    [Table("SetorVeiculos")]
    public class SetorVeiculos
    {
        [Key]
        [Required]
        [Column("Id_Setor")]
        [NotNull]
        public Setores Id_Setor { get; set; }

        [Key]
        [Required]
        [Column("Id_Veiculo")]
        [NotNull]
        public Frotas Id_Veiculo { get; set; }
    }
}
