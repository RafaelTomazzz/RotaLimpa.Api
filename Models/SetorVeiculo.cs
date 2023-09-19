using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Table("SetorVeiculos")]
    [PrimaryKey(nameof(Id_Setor))] //Id veiculo tambem é uma pk, perguntar para o bruno como declarar
    public class SetorVeiculo
    {
        [Key]
        [ForeignKey("idSetor")]
        public int Id_Setor { get; set; }
        public virtual Setor Setor { get; set; }

        [Key]
        [ForeignKey("idVeiculo")]
        public int Id_Veiculo { get; set; }
        public Frota Frota { get; set; }
    }
}
