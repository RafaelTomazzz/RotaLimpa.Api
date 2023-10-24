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
    [PrimaryKey(nameof(Id))]
    public class Trajeto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        [NotNull]
        public int Id { get; set; }

        [ForeignKey("Id_Motorista")]
        public int IdMotorista { get; set; }
        [NotMapped]
        public Motorista Motorista { get; set; }

        [ForeignKey("Id_Rota")]
        public int IdRota { get; set; }
        [NotMapped]
        public Rota Rota { get; set; }

        [ForeignKey("Id_Frota")]
        public int IdFrota { get; set; }
        [NotMapped]
        public Frota Frota { get; set; }
        
        [Required]
        [Comment("Momento de início do trajeto")]
        [Column("Mi_Trajeto")]
        [NotNull]
        public DateTime MiTrajeto { get; set; } = DateTime.Now;
        [Required]
        [Comment("Momento do fim do trajeto")]
        [Column("Mj_Trajeto")]
        [NotNull]
        public DateTime MjTrajeto { get; set; }
    }
}
