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
    [PrimaryKey(nameof(Id))]
    public class Setor
    {
        public ICollection<Rota>? Rotas { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Id_Colaborador")]
        public int ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }
        
        [Required]
        [ForeignKey("Id_Empresa")]
        public int EmpresaId { get; set; }
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
