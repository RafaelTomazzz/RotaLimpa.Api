using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Table("SetorVeiculo")]
    [PrimaryKey(nameof(IdSetor))]
    public class SetorVeiculo
    {
        [Key]
        [ForeignKey("Id_Setor")]
        public int IdSetor { get; set; }
        [NotMapped]
        public virtual Setor Setor { get; set; }

        [Key]
        [ForeignKey("Id_Frota")]
        public int IdFrota { get; set; }
        [NotMapped]
        public Frota Frota { get; set; }
    }
}