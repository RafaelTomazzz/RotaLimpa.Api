using System;
using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD:Models/Periodos.cs
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
=======
>>>>>>> origin/Rafael:Models/Periodo.cs
using Microsoft.EntityFrameworkCore;

namespace RotaLimpa.Api.Models
{
    [Table("Periodos")]
    [PrimaryKey(nameof(Id))]
    public class Periodo
    {
<<<<<<< HEAD:Models/Periodos.cs
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdPeriodo")]
        public int Id_Periodo { get; set; }

        [Required]
        [StringLength(15)]
        [Comment("Descrição do Período")]
        [NotNull]
=======
        public ICollection<Rota>? Rotas { get; set; }

        [Key]
        public int Id { get; set; }
>>>>>>> origin/Rafael:Models/Periodo.cs
        public string Ds_Periodo { get; set; }

        [Required]
        [StringLength(5)]
        [Comment("Hora de Início do Período")]
        [NotNull]
        public string Mi_Periodo { get; set; }

        [Required]
        [StringLength(5)]
        [Comment("Hora do fim do Período")]
        [NotNull]
        public string Mf_Periodo { get; set; }
    }
}
