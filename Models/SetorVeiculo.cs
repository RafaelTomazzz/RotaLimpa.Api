using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Table("SetorVeiculo")]
    [PrimaryKey(nameof(IdSetorVeiculo))]
    public class SetorVeiculo
    {
        
        [Key]
        [ForeignKey("Id_Setor_Veiculo")]
        public int IdSetorVeiculo { get; set; }
        public virtual Setor Setor { get; set; }

        [Key]
        [ForeignKey("Id_Frota")]
        public int IdFrota { get; set; }
        public Frota Frota { get; set; }
    }
}
