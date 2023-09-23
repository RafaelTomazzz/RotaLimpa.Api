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
    [Table("Trajetos")]
    [PrimaryKey(nameof(Id))]
    public class Trajeto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idTrajeto")]
        [NotNull]
        public int Id { get; set; }

        
        public Motorista Id_Motorista { get; set; }
        public Rota Id_Rota { get; set; }
        public Frota Id_Veiculo { get; set; }
        
        [Required]
        [Comment("Momento de início do trajeto")]
        [NotNull]
        public DateTime Mi_Trajeto { get; set; }
        [Required]
        [Comment("Momento do fim do trajeto")]
        [NotNull]
        public DateTime Mj_Trajeto { get; set; }
    }
}
