using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Table("Ruas")]
    [PrimaryKey(nameof(Id))]
    public class Rua
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Cep")]
        public string Cep { get; set; }
        [NotMapped]
        public virtual CEP CEP { get; set; }
        //public Rota Id_Rota { get; set; }
    }
}
