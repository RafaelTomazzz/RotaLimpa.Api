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
        public Colaborador Id_Colaborador { get; set; }
        public Empresa Id_Empresa { get; set; }
        public TiposServico Servico { get; set; }
        public DateTime Di_Setor { get; set; }
        public DateTime Da_Setor { get; set; }
        public string St_Setor { get; set; }
    }
}
