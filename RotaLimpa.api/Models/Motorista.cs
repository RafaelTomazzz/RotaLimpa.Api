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
        public ICollection<HisLoginM>? HisLoginMs { get; set; }
        public ICollection<Trajeto>? Trajetos { get; set; } 
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        [Column("Primeiro_Nome")]
        [NotNull]
        public string PNome { get; set; }

        [Required]
        [StringLength(20)]
        [Column("Sobre_Nome")]
        [NotNull]
        public string SNome { get; set; }
        
        [Comment("Data de cria��o do Motorista")]
        [Column("Di_Motorista")]
        public DateTime Di_Motorista { get; set; } = DateTime.Now;

        [Column("St_Motorista")]
        [StringLength(1)]
        public string StMotorista { get; set; } = "1";
        
        [Required]
        [Column("CPF")]
        [StringLength(15)]
        [NotNull]
        public string Cpf { get; set; }

        [Required]
        [Column("RG")]
        [StringLength(15)]
        [NotNull]
        public string Rg { get; set; }

        private string Chave { get; set; }
        private string IV { get; set; }

        [Required]
        [Column("Login")]
        [StringLength(7)]
        [NotNull]
        public string Login { get; set; }

        [Required]
        [Column("Senha")]
        [StringLength(12)]
        [NotNull]
        public string Senha { get; set; }
    }
}
