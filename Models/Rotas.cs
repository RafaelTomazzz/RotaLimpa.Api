using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RotaLimpa.Api.Models
{
    [Table("Rotas")]
    public class Rotas
    {
        public int Id_Rota { get; set; }
        public Colaboradores Id_Colaborador { get; set; }
        public Periodos Id_Periodos { get; set; }
        public Setores Id_Setor { get; set; }
        public int Dt_Rota { get; set; }
        public int Tm_Rota { get; set; }
    }
}
