using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace RotaLimpa.Api.Models
{
    [Table("HistoLonginColaborador")]
    [PrimaryKey(nameof(IdHisLoginC))]
    public class HisLoginC
    {
        [Key]
        [Column("Historico_Login")]
        public string IdHisLoginC { get; set; }

        [Required]
        [ForeignKey("Id_Colaborador")]
        public int IdColaborador { get; set; }
        [NotMapped]
        public Colaborador Colaborador { get; set; }

        public DateTime DataHora { get; set; } = DateTime.Now;

    }
}
