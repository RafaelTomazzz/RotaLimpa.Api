using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RotaLimpa.Api.Models
{
    [Table("Periodo")]
    [PrimaryKey(nameof(Id))]
    public class Periodo
    {
        public ICollection<Rota>? Rotas { get; set; }

        [Key]
        public int Id { get; set; }
        [Column("Ds_Periodo")]
        public string DsPeriodo { get; set; }
        [Column("Mi_Periodo")]
        public string MiPeriodo { get; set; }
        [Column("Mf_Periodo")]
        public string MfPeriodo { get; set; }
    }
}