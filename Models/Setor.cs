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
    [Table("Setores")]
    [PrimaryKey(nameof(Id))]
    public class Setor
    {
        public ICollection<Rota>? Rotas { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("idColaborador")]
        public int Id_Colaborador { get; set; }
        public virtual Colaborador Colaborador { get; set; }
        
        [Required]
        [ForeignKey("idEmpresa")]
        public int Id_Empresa { get; set; }
        public Empresa Empresa { get; set; }

        public TiposServico TipoServico { get; set; }
        public DateTime Di_Setor { get; set; }
        public DateTime Da_Setor { get; set; }
        public string St_Setor { get; set; }
    }
}
