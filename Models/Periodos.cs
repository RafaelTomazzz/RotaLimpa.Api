using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Table("Periodos")]
    public class Periodos
    {
        public int Id_Periodo { get; set; }
        public string Ds_Periodo { get; set; }
        public string Mi_Periodo { get; set; }
        public string Mf_Periodo { get; set; }
    }
}
