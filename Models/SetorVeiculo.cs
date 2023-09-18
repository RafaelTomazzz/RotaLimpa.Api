using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RotaLimpa.Api.Models
{
    [Table("SetorVeiculos")]
    public class SetorVeiculo
    {
        [Key]
        public Setor Id_Setor { get; set; }

        [Key]
        public Frota Id_Veiculo { get; set; }
    }
}
