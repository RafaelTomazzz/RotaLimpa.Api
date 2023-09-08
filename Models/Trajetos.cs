using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Index(nameof(Id_Trajeto), IsUnique = true)]
    [PrimaryKey(nameof(Id_Trajeto))]
    [Table("Trajetos")]
    public class Trajetos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idTrajeto")]
        [NotNull]
        public int Id_Trajeto { get; set; }

        [ForeignKey("Id_Motoristas")]
        [Required]
        [NotNull]
        public Motoristas Id_Motorista { get; set; }

        [ForeignKey("Id_Rota")]
        [Required]
        [NotNull]
        public Rotas Id_Rota { get; set; }

        [ForeignKey("Id_Veiculo")]
        [Required]
        [NotNull]
        public Frotas Id_Veiculo { get; set; }

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
