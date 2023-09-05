using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RotaLimpa.Api.Models
{
    [Table("SetorVeiculos")]
    public class SetorVeiculos
    {
        [Key]
        public Setores Id_Setor { get; set; }

        [Key]
        public Frotas Id_Veiculo { get; set; }
    }
}
