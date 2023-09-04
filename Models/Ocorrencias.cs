using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RotaLimpa.Api.Models.Enuns;


namespace RotaLimpa.Api.Models
{
    [Table("Ocorrencias")]
    public class Ocorrencias
    {
        [Key]
        public int Id_Ocorrencia { get; set; }
        public Trajetos Id_Trajeto { get; set; }
        public TiposOcorrencias Ocorrencia { get; set; }
        public DateTime Mt_Ocorrencia { get; set; }
    }
}
