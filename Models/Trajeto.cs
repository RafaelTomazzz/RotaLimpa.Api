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
        [Column("IdTrajeto")]
        [NotNull]
        public int Id { get; set; }
        public int IdMotorista { get; set; }
        public Motorista Motorista { get; set; }
        public int IdRota { get; set; }
        public Rota Rota { get; set; }

<<<<<<< HEAD
        [ForeignKey("idMotorista")]
        public Motorista Id_Motorista { get; set; }

        [ForeignKey("idRota")]
        public Rota Id_Rota { get; set; }

        [ForeignKey("idVeiculo")]
        public Frota Id_Veiculo { get; set; }
=======
        public int IdFrota { get; set; }
        public Frota Frota { get; set; }
>>>>>>> origin/Rafael
        
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
