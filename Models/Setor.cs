using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RotaLimpa.api.Models.Enuns;

namespace RotaLimpa.Api.Models
{
    [Table("Setores")]
    public class Setor
    {
        [Key]
        public int Id_Setor { get; set; }

        [Required]
        [ForeignKey("idColaborador")]
        public int Id_Colaborador { get; set; }
        public virtual Colaborador Colaborador { get; set; }
        
        [Required]
        [ForeignKey("idEmpresa")]
        public int Id_Empresa { get; set; }
        public Empresa Empresa { get; set; }

        [Required]
        [ForeignKey("idTipoServico")]
        public int Id_TipoServico { get; set; }
        public TiposServico TipoServico { get; set; }
        public DateTime Di_Setor { get; set; }
        public DateTime Da_Setor { get; set; }
        public string St_Setor { get; set; }
    }
}
