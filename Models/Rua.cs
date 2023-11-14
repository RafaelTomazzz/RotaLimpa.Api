using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Table("Rua")]
    [PrimaryKey(nameof(Id))]
    public class Rua
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Id_Cep")]
        public int IdCep { get; set; }
        public CEP? CEP { get; set; }
        
        [Required]
        [ForeignKey("Id_Rota")]
        public int IdRota { get; set; }
        public virtual Rota? Rota { get; set; }
    }
}
