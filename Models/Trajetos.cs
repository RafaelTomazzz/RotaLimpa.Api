using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Table("Trajetos")]
    public class Trajetos
    {
        [Key]
        public int Id_Trajeto { get; set; }

        [ForeignKey("Id_Motoristas")]
        [Required]
        public Motoristas Id_Motorista { get; set; }

        [ForeignKey("Id_Rota")]
        [Required]
        public Rotas Id_Rota { get; set; }

        [ForeignKey("Id_Veiculo")]
        [Required]
        public Frotas Id_Veiculo { get; set; }

        [Required]
        public DateTime Mi_Trajeto { get; set; }

        [Required]
        public DateTime Mj_Trajeto { get; set; }
    }
}
