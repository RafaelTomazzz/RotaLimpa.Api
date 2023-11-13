using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RotaLimpa.api.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace RotaLimpa.Api.Models
{
    [Table("Setor")]
    [PrimaryKey(nameof(IdSetor))]
    public class Setor
    {
        public ICollection<Rota>? Rotas { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_Setor")]
        public int IdSetor { get; set; }

        [Required]
        [ForeignKey("Id_Colaborador")]
        public int ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }
        
        [Required]
        [ForeignKey("Id_Empresa")]
        public int IdEmpresa { get; set; }
        [NotMapped]
        public Empresa Empresa { get; set; }

        public TiposServico TipoServico { get; set; }
        [Column("Di_Setor")]
        public DateTime DiSetor { get; set; }
        [Column("Da_Setor")]
        public DateTime DaSetor { get; set; }
        [Column("St_Setor")]
        public string StSetor { get; set; }
    }
}
