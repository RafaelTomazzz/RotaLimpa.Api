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
    [PrimaryKey(nameof(IdMotorista))]
    public class Motorista
    {
        public ICollection<HisLoginM>? HisLoginMs { get; set; }
        public ICollection<Trajeto>? Trajetos { get; set; }        

        [Key]
        [Column("Id_Motorista")]
        public int IdMotorista { get; set; }

        [Column("Nm_Motorista")]
        [Comment("Nome do motorista")]
        [NotNull]
        public string NomeMotorista { get; set; }
        
        [Comment("Data de cria��o do Motorista")]
        [Column("Di_Motorista")]
        public DateTime Di_Motorista { get; set; } = DateTime.Now;

        [Column("St_Motorista")]
        [StringLength(1)]
        public string StMotorista { get; set; }
        
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
        [StringLength(20)]
        [NotNull]
        public string Login { get; set; }

        [Required]
        [Column("Senha")]
        [StringLength(12)]
        [NotNull]
        public string Senha { get; set; }

        [Required]
        [Column("Historico_Login")]
        [StringLength(25)]
        [NotNull]
        public string IdHisLoginM { get; set; }
    }
}
