using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RotaLimpa.Api.Models
{
    [Table("Trajeto")]
    [PrimaryKey(nameof(IdTrajeto))]
    public class Trajeto
    {
        public ICollection<Ocorrencia> Ocorrencias { get; set; }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_Trajeto")]
        [NotNull]
        public int IdTrajeto { get; set; }
        
        public int IdMotorista { get; set; }
        public Motorista Motorista { get; set; }

        public int IdRota { get; set; }
        public Rota Rota { get; set; }


        public int IdFrota { get; set; }
        public Frota Frota { get; set; }

        
        [Required]
        [ForeignKey("Id_Periodo")]
        public int IdPeriodo { get; set; }
        public Periodo Periodo { get; set; }
        
        [Required]
        [Comment("Momento de início do trajeto")]
        [Column("Mi_Trajeto")]
        [NotNull]
        public DateTime MiTrajeto { get; set; } = DateTime.Now;

        [Required]
        [Comment("Momento do fim do trajeto")]
        [Column("Mf_Trajeto")]
        [NotNull]
        public DateTime MfTrajeto { get; set; }
    }
}
