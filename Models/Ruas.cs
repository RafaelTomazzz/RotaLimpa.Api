using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using RotaLimpa.Api.Models.Enuns;

namespace RotaLimpa.Api.Models
{
    [Index(nameof(Id_Ruas), IsUnique = true)]
    [PrimaryKey(nameof(Id_Ruas))]
    [Table("Ruas")]
    public class Ruas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_Ruas")]
        public int Id_Ruas { get; set; }

        [Required]
        [ForeignKey("Cep")]
        public int Id_Cep { get; set; }
        public CEP Cep { get; set; }

        [Required]
        [ForeignKey("Rotas")]
        public int Id_Rota { get; set; }
        public Rotas Rota { get; set; }
    }
}
