using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RotaLimpa.api.Models;
using RotaLimpa.api.Models.Enuns;

namespace RotaLimpa.Api.Models
{
    [Table("Setores")]
    public class Setores
    {
        [Key]
        public int Id_Setor { get; set; }
        public Colaboradores Id_Colaborador { get; set; }
        public Empresas Id_Empresa { get; set; }
        public TiposServicos Servico { get; set; }
        public DateTime Di_Setor { get; set; }
        public DateTime Da_Setor { get; set; }
        public string St_Setor { get; set; }
    }
}
