using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Table("Rua")]
    [PrimaryKey(nameof(IdRua))]
    public class Rua
    {
        [Key]
        [Column("Id_Rua")]
        public int IdRua { get; set; }

        [Required]
        [ForeignKey("Cep")]
        public string IdCep { get; set; }
        public CEP CEP { get; set; }
        
        [Required]
        [ForeignKey("Id_Rota")]
        public int RotaId { get; set; }
        public virtual Rota Rota { get; set; }
    }
}
