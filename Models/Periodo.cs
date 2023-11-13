using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RotaLimpa.Api.Models
{
    [Table("Periodo")]
    [PrimaryKey(nameof(IdPeriodo))]
    public class Periodo
    {
        public ICollection<Trajeto>? Trajetos { get; set; }

        [Key]
        [Column("Id_Periodo")]
        public int IdPeriodo { get; set; }

        [Column("Ds_Periodo")]
        public string DsPeriodo { get; set; }

        [Column("Mi_Periodo")]
        public string MiPeriodo { get; set; }
        
        [Column("Mf_Periodo")]
        public string MfPeriodo { get; set; }
    }
}
