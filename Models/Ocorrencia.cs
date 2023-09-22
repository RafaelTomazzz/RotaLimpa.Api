using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RotaLimpa.Api.Models.Enum;


namespace RotaLimpa.Api.Models
{
    [Table("Ocorrencias")]
    public class Ocorrencia
    {
        [Key]
        public int Id_Ocorrencia { get; set; }
        public Trajeto Id_Trajeto { get; set; }
        public TiposOcorrencia Tipo_Ocorrencia { get; set; }
        public DateTime Mt_Ocorrencia { get; set; }
    }
}
