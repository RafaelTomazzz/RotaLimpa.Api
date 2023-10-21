using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace RotaLimpa.Api.Models
{
    [Table("Motorista")]
    public class Motorista
    {
        [Key]
        [Column("Id")]
        public int IdMotorista { get; set; }
        [Column("Nm_Motorista")]
        [Comment("Nome do motorista")]
        [NotNull]
        public string NomeMotorista { get; set; }
        [Comment("Data de cria��o do Motorista")]
        [Column("Dc_Motorista")]
        public DateTime Dc_Motorista { get; set; } = DateTime.Now;
        [Column("St_Motorista")]
        public string StMotorista { get; set; }
    }
}
